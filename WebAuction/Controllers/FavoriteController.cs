using Microsoft.AspNetCore.Mvc;
using WebAuction.Services;


namespace WebAuction.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly FavoriteServices favoriteServices;

        public FavoriteController(FavoriteServices favoriteServices)
        {
            this.favoriteServices = favoriteServices;
        }
        public IActionResult Index()
        {
            return View(favoriteServices.GetLots());
        }

        public IActionResult Add(int id)
        {
            favoriteServices.AddItem(id);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            favoriteServices.RemoveItem(id);

            return RedirectToAction("Index");
        }

    }
}
