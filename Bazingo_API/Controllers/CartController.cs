using Bazingo_Application.DTO_s.Cart;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var result = await _cartService.AddToCart(userId , dto);
            return result ? Ok("Item added to cart") : BadRequest("Failed to add item");
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetCartItems( )
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var items = await _cartService.GetCartItems(userId);
            return Ok(items);
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var result = await _cartService.RemoveFromCart(cartItemId);
            return result ? Ok("Item removed from cart") : NotFound("Item not found");
        }

        [HttpPut("update-quantity")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromBody] UpdateCartItemQuantityDto dto)
        {
            var result = await _cartService.UpdateCartItemQuantity(dto);
            return result ? Ok("Quantity updated successfully") : BadRequest("Update failed");
        }
    }
}
