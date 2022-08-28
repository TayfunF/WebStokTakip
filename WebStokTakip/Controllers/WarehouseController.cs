using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStokTakip.Models;

namespace WebStokTakip.Controllers
{
    [Authorize(Roles = "admin")]
    public class WarehouseController : Controller
    {
        private AppDbContext _context = new AppDbContext();

        // GET: Warehouse
        public ActionResult Index(string searched)
        {
            var AllList = _context.Warehouses.ToList();
            if (!string.IsNullOrEmpty(searched))
            {
                AllList = AllList.Where(x => x.Name.Contains(searched)).ToList();
            }

            return View(AllList);
        }

        //// GET: Warehouse/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Warehouse warehouse = _context.Warehouses.Find(id);
        //    if (warehouse == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(warehouse);
        //}

        // GET: Warehouse/Create

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Capacity,IsActive")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Warehouses.Add(warehouse);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Capacity,IsActive")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(warehouse).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.User.IsInRole("admin"))
            {
                Warehouse warehouse = _context.Warehouses.Find(id);
                _context.Warehouses.Remove(warehouse);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DepoSilmeYetkisiYok"] = "Yetkiniz Yok";
            }
            return RedirectToAction("Delete", "Warehouse");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
