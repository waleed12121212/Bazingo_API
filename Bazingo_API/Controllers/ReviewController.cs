using Bazingo_Application.DTO_s.Review;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewDto dto)
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var result = await _reviewService.AddReview(userId , dto);
            return result ? Ok("Review added successfully") : BadRequest("Failed to add review");
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductReviews(int productId)
        {
            var reviews = await _reviewService.GetProductReviews(productId);
            return Ok(reviews);
        }

        [HttpDelete("delete/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await _reviewService.DeleteReview(reviewId);
            return result ? Ok("Review deleted successfully") : NotFound("Review not found");
        }

        [HttpGet("user-reviews")]
        public async Task<IActionResult> GetUserReviews( )
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var reviews = await _reviewService.GetUserReviews(userId);
            return Ok(reviews);
        }
    }
}
