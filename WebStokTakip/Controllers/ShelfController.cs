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
    public class ShelfController : Controller
    {
        private AppDbContext _context = new AppDbContext();

        // GET: Shelf
        public ActionResult Index(string searched)
        {
            var shelves = _context.Shelves.Include(s => s.Warehouse).ToList();
            if (!string.IsNullOrEmpty(searched))
            {
                shelves = shelves.Where(x => x.Name.Contains(searched)).ToList();
            }

            return View(shelves);
        }

        //// GET: Shelf/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Shelf shelf = _context.Shelves.Find(id);
        //    if (shelf == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(shelf);
        //}

        // GET: Shelf/Create
        public ActionResult Create()
        {
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name");
            return View();
        }

        // POST: Shelf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                _context.Shelves.Add(shelf);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name", shelf.WarehouseId);
            return View(shelf);
        }

        // GET: Shelf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = _context.Shelves.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name", shelf.WarehouseId);
            return View(shelf);
        }

        // POST: Shelf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(shelf).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name", shelf.WarehouseId);
            return View(shelf);
        }

        // GET: Shelf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = _context.Shelves.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            return View(shelf);
        }

        // POST: Shelf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.User.IsInRole("admin"))
            {
                Shelf shelf = _context.Shelves.Find(id);
                _context.Shelves.Remove(shelf);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["RafSilmeYetkisiYok"] = "Yetkiniz Yok";
            }
            return RedirectToAction("Delete", "Shelf");
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
