using Core.Dtos;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAuction.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILotService _lotService;

        public OrdersController(IOrderService orderService, ILotService lotService)
        {
            _orderService = orderService;
            _lotService = lotService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _orderService.GetUserOrders(userId);

            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        public IActionResult Create(int lotId, int finalPrice)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orderDto = new OrderDto
            {
                LotId = lotId,
                UserId = userId,
                FinalPrice = finalPrice
            };

            _orderService.CreateOrder(orderDto);

            return RedirectToAction("Index");
        }
        public IActionResult GenerateOrders()
        {
            _orderService.CreateOrdersAtEndOfDay();
            return RedirectToAction("Index");
        }

    }
}
