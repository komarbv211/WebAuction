using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Data.Data;
using WebAuction.Models;
using AutoMapper;
using Core.Interfaces;

namespace WebAuction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILotService _lotService;

        public HomeController(ILotService lotService)
        {
            _lotService = lotService;
        }

        public IActionResult Index()
        {
            var lots = _lotService.GetActiveLots();
            return View(lots);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
