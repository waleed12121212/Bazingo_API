using Bazingo_Application.DTO_s.Auction;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuction([FromBody] CreateAuctionDto dto)
        {
            var result = await _auctionService.CreateAuction(dto);
            return result ? Ok("Auction created successfully") : BadRequest("Auction creation failed");
        }

        [HttpPost("place-bid")]
        public async Task<IActionResult> PlaceBid([FromBody] PlaceBidDto dto)
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var result = await _auctionService.PlaceBid(userId , dto);
            return result ? Ok("Bid placed successfully") : BadRequest("Bid placement failed");
        }

        [HttpGet("{auctionId}")]
        public async Task<IActionResult> GetAuctionDetails(int auctionId)
        {
            var auction = await _auctionService.GetAuctionDetails(auctionId);
            return auction != null ? Ok(auction) : NotFound("Auction not found");
        }
    }
}
