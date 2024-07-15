using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Data.Data;
using WebAuction.Models;

namespace WebAuction.Controllers
{
    public class HomeController : Controller
    {
        private AuctionDbContext context = new();
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var lots = context.Lots
                .Include(x => x.Category)
                .ToList();
            return View(lots);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
