using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStokTakip.Models;
using WebStokTakip.Models.Identity;

namespace WebStokTakip.Controllers
{
    public class KMOController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public KMOController()
        {
            var UserStore = new UserStore<ApplicationUser>(new AppDbContext());
            UserManager = new UserManager<ApplicationUser>(UserStore);
            var RoleStore = new RoleStore<ApplicationRole>(new AppDbContext());
            RoleManager = new RoleManager<ApplicationRole>(RoleStore);
        }

        // GET: KMO
        public ActionResult _Acc()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Acc(Login Login, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var User = UserManager.Find(Login.Username, Login.Password);

                if (User != null)
                {
                    //Kullanıcı varsa. Var olan kullanıcıyı sisteme dahil et
                    //ApplicationCokkie oluştur ve sisteme bırak

                    var AuthManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = UserManager.CreateIdentity(User, "ApplicationCookie");
                    var AuthProperties = new AuthenticationProperties();
                    AuthProperties.IsPersistent = Login.RememberMe;
                    AuthManager.SignIn(AuthProperties, IdentityClaims);

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "WarehouseStock");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle Bir Kullanıcı Yok");
                }
            }

            return View(Login);
        }

        public ActionResult _AccOut()
        {
            var AuthManager = HttpContext.GetOwinContext().Authentication;
            AuthManager.SignOut();

            return RedirectToAction("_Acc", "KMO");
        }
    }
}