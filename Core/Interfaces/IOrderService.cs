using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);
        List<OrderDto> GetUserOrders(string userId);
        OrderDto GetOrderById(int id);
        Task CreateOrdersAtEndOfDay();
    }
}
