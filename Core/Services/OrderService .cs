using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Core.Models;
using Data.Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly AuctionDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IViewRender _viewRender;
        private readonly IConfiguration _configuration;
        public OrderService(AuctionDbContext context, IMapper mapper, IEmailSender emailSender, IViewRender viewRender, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _emailSender = emailSender;
            _viewRender = viewRender;
            _configuration = configuration;
        }

        public void CreateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<OrderDto> GetUserOrders(string userId)
        {
            var orders = _context.Orders
                .Where(o => o.UserId == userId)
                .ToList();

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }
        public async Task CreateOrdersAtEndOfDay()
        {
            var lots = await GetLotsToProcess();
            foreach (var lot in lots)
            {
                var order = await CreateOrderForLot(lot);
                if (order != null)
                {
                    await SendOrderEmail(order);
                }
            }
        }

        private async Task<List<Lot>> GetLotsToProcess()
        {
            return await _context.Lots
                .Where(l => l.StartOfBidding.Date <= DateTime.Today && l.StartOfBidding.Date.AddDays(1) <= DateTime.Now && l.HighestBid > 0)
                .ToListAsync();
        }

        private async Task<Order> CreateOrderForLot(Lot lot)
        {
            if (lot.StartOfBidding.Date.AddDays(1) > DateTime.Now)
                return null;

            var highestBidder = _context.Bids
                .Where(b => b.LotId == lot.Id)
                .OrderByDescending(b => b.Amount)
                .Select(b => b.BidderId)
                .FirstOrDefault();

            if (highestBidder == null)
                return null;

            var existingOrder = await _context.Orders
                .AnyAsync(o => o.LotId == lot.Id && o.UserId == highestBidder);

            if (existingOrder)
                return null;

            var order = new Order
            {
                LotId = lot.Id,
                UserId = highestBidder,
                FinalPrice = lot.HighestBid,
                DateWon = DateTime.Now
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private async Task SendOrderEmail(Order order)
        {
            var winner = _context.Users.Find(order.UserId);
            var lotDetails = _context.Lots
                .Where(l => l.Id == order.LotId)
                .Select(l => new LotDto
                {
                    Name = l.Name,
                    HighestBid = l.HighestBid
                }).ToList();

            var emailModel = new OrderSummaryModel
            {
                UserName = winner?.UserName ?? "Шановний користувачу",
                OrderNumber = order.Id,
                TotalPrice = order.FinalPrice,
                Lots = lotDetails
            };

            var emailBody = _viewRender.Render("OrderSummary", emailModel);
            await _emailSender.SendEmailAsync(winner?.Email ?? "unknown@example.com", "Вітаємо з виграшем!", emailBody);
        }

    }
}
