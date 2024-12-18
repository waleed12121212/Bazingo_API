using Bazingo_Core.Interfaces;
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

        public IUserRepository Users { get; private set; }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IReviewRepository Reviews { get; private set; }
        public IAuctionRepository Auctions { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            // Initializing repositories
            Users = new UserRepository(context);
            Products = new ProductRepository(context);
            Orders = new OrderRepository(context);
            Categories = new CategoryRepository(context);
            Reviews = new ReviewRepository(context);
            Auctions = new AuctionRepository(context);
        }

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
