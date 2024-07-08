using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuction.Data;
using WebAuction.Entities;

namespace WebAuction.Controllers
{
    public class LotsController : Controller
    {
        private AuctionDbContext ctx = new AuctionDbContext();
        public LotsController()
        {
        }
        public IActionResult Index()
        {
            var products = ctx.Lots
                .Include(x => x.Category)
                .Where(x => !x.Archived)
                .ToList();

            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lot model)
        {
            ctx.Lots.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Archive()
        {
            var lot = ctx.Lots
                .Include(x => x.Category) 
                .Where(x => x.Archived)
                .ToList();

            return View(lot);
        }

        public IActionResult ArchiveItem(int id)
        {
            var product = ctx.Lots.Find(id);

            if (product == null) return NotFound();

            product.Archived = true;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = ctx.Lots.Find(id);

            if (product == null) return NotFound();

            ctx.Lots.Remove(product);
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }
        public IActionResult RestoreItem(int id)
        {
            var product = ctx.Lots.Find(id);

            if (product == null) return NotFound();

            product.Archived = false;
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }
    }
}
