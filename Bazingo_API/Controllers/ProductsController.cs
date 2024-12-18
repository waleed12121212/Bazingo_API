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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts( )
        {
            var products = await _context.Products
                .Include(p => p.Seller)
                .ToListAsync();
            var productDtos = products.Adapt<IEnumerable<ProductResponseDTO>>();
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.ProductID == id);

            if (product == null)
                return NotFound();

            var productDto = product.Adapt<ProductResponseDTO>();
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = productCreateDto.Adapt<Product>();
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productResponseDto = product.Adapt<ProductResponseDTO>();
            return CreatedAtAction(nameof(GetProduct) , new { id = productResponseDto.ProductID } , productResponseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id , [FromBody] ProductUpdateDTO productUpdateDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            productUpdateDto.Adapt(product);
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
