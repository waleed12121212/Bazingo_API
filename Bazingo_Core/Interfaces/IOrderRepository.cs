using Bazingo_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId);
        Task<Order> GetOrderWithDetailsAsync(int orderId);
        Task<decimal> GetTotalSalesAsync( );
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
    }
}
