using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Core.Dtos;
using Data.Entities;
using Core.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebAuction.Controllers
{
    public class LotsController : Controller
    {
        private readonly ILotService _lotService;
        private readonly IBidService _bidService;

        public LotsController(ILotService lotService, IBidService bidService)
        {
            _lotService = lotService;
            _bidService = bidService;
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
        public async Task<IActionResult> Create(LotDto lotDto)
        {
            if (ModelState.IsValid)
            {
                await _lotService.CreateLot(lotDto);
                return RedirectToAction("Index");
            }
            return View(lotDto);
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
        public async Task<IActionResult> Edit(LotDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                LoadCategories();
                return View("Upsert", model);
            }

            await _lotService.UpdateLot(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var lot = _lotService.GetLotById(id);
            if (lot == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bid = userId != null ? await _bidService.GetUserBidForLotAsync(id, userId) : null;
            lot.MyRate = bid?.Amount ?? 0;
            return View(lot);
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

        public async Task<IActionResult> Delete(int id)
        {
            await _lotService.DeleteLot(id);

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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PlaceBid(int lotId, int bidAmount)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var success = await _bidService.PlaceBid(lotId, bidAmount, userId);

            if (!success)
            {
                TempData["ErrorMessage"] = "Your bid was too low or the auction is not active.";
            }
            else
            {
                TempData["SuccessMessage"] = "Your bid has been placed successfully!";
            }

            return RedirectToAction("Details", new { id = lotId });
        }
    }
}