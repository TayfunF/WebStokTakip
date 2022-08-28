namespace WebStokTakip.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebStokTakip.Models.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<WebStokTakip.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebStokTakip.Models.AppDbContext _context)
        {
            //Roller
            if (!_context.Roles.Any(i => i.Name == "admin"))
            {
                var Store = new RoleStore<ApplicationRole>(_context);
                var Manager = new RoleManager<ApplicationRole>(Store);
                var Role = new ApplicationRole() { Name = "admin", Description = "Yönetici Rolü" };

                Manager.Create(Role);
            }

            if (!_context.Roles.Any(i => i.Name == "user"))
            {
                var Store = new RoleStore<ApplicationRole>(_context);
                var Manager = new RoleManager<ApplicationRole>(Store);
                var Role = new ApplicationRole() { Name = "user", Description = "Kullanıcı Rolü" };

                Manager.Create(Role);
            }

            if (!_context.Users.Any(i => i.UserName == "tayfunfirtina"))
            {
                var Store = new UserStore<ApplicationUser>(_context);
                var Manager = new UserManager<ApplicationUser>(Store);
                var User = new ApplicationUser() { Name = "Tayfun Firtina", UserName = "tayfunfirtina", Email = "tayfunfirtina@hastavuk.com", };

                Manager.Create(User, "T@yfun1608!");
                Manager.AddToRole(User.Id, "admin");
                Manager.AddToRole(User.Id, "user");
            }

            //if (!_context.Users.Any(i => i.UserName == "muhsinfurkan"))
            //{
            //    var Store = new UserStore<ApplicationUser>(_context);
            //    var Manager = new UserManager<ApplicationUser>(Store);
            //    var User = new ApplicationUser() { Name = "Muhsin Furkan", UserName = "muhsinfurkan", Email = "muhsinfurkan@hotmail.com", };

            //    Manager.Create(User, "P@lin1608!");
            //    Manager.AddToRole(User.Id, "user");
            //}


            base.Seed(_context);
        }
    }
}
