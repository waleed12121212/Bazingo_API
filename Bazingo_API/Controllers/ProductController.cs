using Bazingo_Application.DTO_s.Product;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts( )
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);
            return product != null ? Ok(product) : NotFound("Product not found");
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var sellerId = User.Identity?.Name ?? "Unknown";
            var result = await _productService.CreateProduct(sellerId , dto);
            return result ? Ok("Product created successfully") : BadRequest("Product creation failed");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto dto)
        {
            var sellerId = User.Identity?.Name ?? "Unknown";
            var result = await _productService.UpdateProduct(sellerId , dto);
            return result ? Ok("Product updated successfully") : BadRequest("Product update failed");
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _productService.DeleteProduct(productId);
            return result ? Ok("Product deleted successfully") : BadRequest("Product deletion failed");
        }
    }
}
