using Bazingo_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId);
        Task<decimal> GetAverageRatingAsync(int productId);
        Task<int> GetTotalReviewsAsync(int productId);
    }
}
