using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Core.Dtos;
using Data.Entities;
using Core.Interfaces;

namespace WebAuction.Controllers
{
    public class LotsController : Controller
    {
        private readonly ILotService _lotService;

        public LotsController(ILotService lotService)
        {
            _lotService = lotService;
        }

        public IActionResult Index()
        {
            var lots = _lotService.GetActiveLots();

            return View(lots);
        }
        public IActionResult Create()
        {
            LoadCategories();
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(LotDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                LoadCategories();
                return View("Upsert", model);
            }
            _lotService.CreateLot(model);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lot = _lotService.GetLotById(id);

            if (lot == null) return NotFound();

            LoadCategories();
            ViewBag.CreateMode = false;
            return View("Upsert", lot);
        }

        [HttpPost]
        public IActionResult Edit(LotDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                LoadCategories();
                return View("Upsert", model);
            }
            _lotService.UpdateLot(model);

            return RedirectToAction("Index");
        }

        public IActionResult Archive()
        {
            var lots = _lotService.GetArchivedLots();

            return View(lots);
        }

        public IActionResult ArchiveItem(int id)
        {
           _lotService.ArchiveLot(id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _lotService.DeleteLot(id);

            return RedirectToAction("Archive");
        }
        public IActionResult RestoreItem(int id)
        {
            _lotService.RestoreLot(id);

            return RedirectToAction("Archive");
        }
        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(_lotService.GetCategories(), "Id", "Name");
        }
    }
}