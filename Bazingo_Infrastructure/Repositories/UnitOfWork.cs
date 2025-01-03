using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
            Orders = new OrderRepository(context);
        }

        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public async Task<int> CompleteAsync( )
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose( )
        {
            _context.Dispose();
        }
    }
}
