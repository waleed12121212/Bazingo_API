using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazingo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders( )
        {
            var orders = await _context.Orders
                .Include(o => o.Buyer)
                .ToListAsync();
            var orderDtos = orders.Adapt<IEnumerable<OrderResponseDTO>>();
            return Ok(orderDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDTO orderCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = orderCreateDto.Adapt<Order>();
            order.CreatedAt = DateTime.UtcNow;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderResponseDto = order.Adapt<OrderResponseDTO>();
            return CreatedAtAction(nameof(GetOrders) , new { id = orderResponseDto.OrderID } , orderResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
