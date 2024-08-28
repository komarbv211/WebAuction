using Core.Interfaces; // Переконайтеся, що цей простір імен правильний
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebAuction.Services
{
    public class AuctionBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AuctionBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                    await orderService.CreateOrdersAtEndOfDay();
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken); // Виклик раз на день
            }
        }
    }
}
