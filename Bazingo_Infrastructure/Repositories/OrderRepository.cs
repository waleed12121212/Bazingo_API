using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId)
        {
            return await _dbSet.Where(o => o.BuyerID == userId).ToListAsync();
        }
    }
}
