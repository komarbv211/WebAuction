using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using WebAuction.Extensions;

namespace WebAuction.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly AuctionDbContext context;
        private readonly IMapper mapper;

        public FavoriteController(AuctionDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>("favorite_items") ?? new();

            var products = context.Lots.Include(x => x.Category).Where(x => ids.Contains(x.Id)).ToList();

            return View(mapper.Map<List<LotDto>>(products));
        }

        public IActionResult Add(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null) ids = new();
            ids.Add(id);

            HttpContext.Session.Set("favorite_items", ids);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null || !ids.Contains(id)) return NotFound();
            ids.Remove(id);

            HttpContext.Session.Set("favorite_items", ids);

            return RedirectToAction("Index");
        }
    }
}
