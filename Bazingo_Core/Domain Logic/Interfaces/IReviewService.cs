using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IReviewService
    {
        Task<bool> AddReview(string userId , AddReviewDto dto);
        Task<IEnumerable<ReviewDto>> GetProductReviews(int productId);
        Task<bool> DeleteReview(int reviewId);
        Task<IEnumerable<ReviewDto>> GetUserReviews(string userId);
    }
}
