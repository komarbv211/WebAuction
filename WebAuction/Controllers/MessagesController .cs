using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebAuction.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Security.Claims;

namespace WebAuction.Controllers
{
    public class MessagesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;

        public MessagesController(UserManager<User> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var users = _userManager.Users.ToList();
            var model = new MessageViewModel
            {
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<User> recipients;
                if (model.SendToAll)
                {
                    // Отримати всіх користувачів
                    recipients = _userManager.Users.ToList();
                }
                else
                {
                    // Отримати вибраного користувача
                    var user = await _userManager.FindByIdAsync(model.SelectedUserId);
                    recipients = user != null ? new List<User> { user } : new List<User>();
                }

                if (recipients.Any())
                {
                    foreach (var recipient in recipients)
                    {
                        // Надіслати електронний лист
                        await _emailSender.SendEmailAsync(recipient.Email, model.Subject, model.Body);

                        // Зберегти повідомлення в базу даних (опціонально)
                        var message = new Message
                        {
                            SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                            ReceiverId = recipient.Id,
                            Subject = model.Subject,
                            Body = model.Body,
                            SentDate = DateTime.Now
                        };

                        // Зберегти повідомлення в базу даних
                        // _context.Messages.Add(message);
                        // await _context.SaveChangesAsync();
                    }

                    TempData["Message"] = "Messages sent successfully!";
                    return RedirectToAction("SendMessage");
                }

                ModelState.AddModelError("", "No recipients found.");
            }

            var users = _userManager.Users.ToList();
            model.Users = users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            }).ToList();

            return View(model);
        }
    }
}
