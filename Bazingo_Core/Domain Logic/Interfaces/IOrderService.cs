using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(string userId , CreateOrderDto dto);
        Task<OrderDto> GetOrderById(int orderId);
        Task<IEnumerable<OrderDto>> GetUserOrders(string userId);
        Task<bool> CancelOrder(int orderId);
        Task<bool> UpdateOrderStatus(UpdateOrderStatusDto dto);
        Task<IEnumerable<OrderDto>> AdminViewAllOrders( );
    }
}
