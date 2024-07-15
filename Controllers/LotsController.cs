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
            var lots = ctx.Lots
                .Include(x => x.Category)
                .Where(x => !x.Archived)
                .ToList();

            return View(lots);
        }
        public IActionResult Create()
        {
            LoadCategories();
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(Lot model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                LoadCategories();
                return View("Upsert", model);
            }
            ctx.Lots.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lot = ctx.Lots.Find(id);

            if (lot == null) return NotFound();

            LoadCategories();
            ViewBag.CreateMode = false;
            return View("Upsert", lot);
        }

        [HttpPost]
        public IActionResult Edit(Lot model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                LoadCategories();
                return View("Upsert", model);
            }
            ctx.Lots.Update(model);
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
            var lot = ctx.Lots.Find(id);

            if (lot == null) return NotFound();

            lot.Archived = true;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var lot = ctx.Lots.Find(id);

            if (lot == null) return NotFound();

            ctx.Lots.Remove(lot);
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }
        public IActionResult RestoreItem(int id)
        {
            var lot = ctx.Lots.Find(id);

            if (lot == null) return NotFound();

            lot.Archived = false;
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        private void LoadCategories()
        {

            ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }
    }
}