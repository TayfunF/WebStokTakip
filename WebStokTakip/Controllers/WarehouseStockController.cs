using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStokTakip.Models;

namespace WebStokTakip.Controllers
{
    [Authorize(Roles = "admin")]
    public class WarehouseStockController : Controller
    {
        AppDbContext _context = new AppDbContext();

        // GET: WarehouseStock
        public ActionResult Index()
        {
            ViewBag.WarehouseCount = _context.Warehouses.Count();
            ViewBag.ShelfCount = _context.Shelves.Count();
            ViewBag.ProductCount = _context.Products.Count();
            ViewBag.CategoryCount = _context.Categories.Count();

            return View();
        }
    }
}