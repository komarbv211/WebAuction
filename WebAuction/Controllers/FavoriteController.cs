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

        public IActionResult Add(int id, string ? returnUrl)
        {
            favoriteServices.AddItem(id);

            return Redirect(returnUrl ?? "/");
        }

        public IActionResult Remove(int id)
        {
            favoriteServices.RemoveItem(id);

            return RedirectToAction("Index");
        }

    }
}
