using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Data.Data;
using WebAuction.Models;
using AutoMapper;

namespace WebAuction.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuctionDbContext context;
        private readonly IMapper mapper;

        public HomeController(AuctionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
