using Bazingo_Core.Interfaces;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductID == productId)
                .ToListAsync();
        }

        public async Task<decimal> GetAverageRatingAsync(int productId)
        {
            return (decimal)await _context.Reviews
                .Where(r => r.ProductID == productId)
                .AverageAsync(r => r.Rating);
        }

        public async Task<int> GetTotalReviewsAsync(int productId)
        {
            return await _context.Reviews.CountAsync(r => r.ProductID == productId);
        }
    }
}
