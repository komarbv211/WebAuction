using Microsoft.AspNetCore.Mvc;
using Core.Dtos;

namespace WebAuction.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Pay(int lotId, string lotName, decimal amount)
        {
            var paymentDto = new PaymentDto
            {
                LotId = lotId,
                LotName = lotName,
                Amount = amount
            };

            return View(paymentDto);
        }

        [HttpPost]
        public IActionResult Pay(PaymentDto payment)
        {
            if (ModelState.IsValid)
            {
                // Реалізувати логіку обробки оплати
                // Наприклад, збереження в базу даних, виклик платіжного API і т.д.

                return RedirectToAction("PaymentSuccess");
            }

            return View(payment);
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }
    }
}
