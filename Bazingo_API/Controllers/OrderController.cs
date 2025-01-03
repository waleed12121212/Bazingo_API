using Bazingo_Application.DTO_s.Order;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var result = await _orderService.CreateOrder(userId , dto);
            return result ? Ok("Order created successfully") : BadRequest("Order creation failed");
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            return order != null ? Ok(order) : NotFound("Order not found");
        }

        [HttpGet("user-orders")]
        public async Task<IActionResult> GetUserOrders( )
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var orders = await _orderService.GetUserOrders(userId);
            return Ok(orders);
        }
    }
}
