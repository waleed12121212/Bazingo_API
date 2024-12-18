using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync( )
        {
            var products = await _context.Products.Include(p => p.Seller).ToListAsync();
            return products.Adapt<IEnumerable<ProductResponseDTO>>();
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.ProductID == id);

            return product?.Adapt<ProductResponseDTO>();
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductCreateDTO productDto)
        {
            var product = productDto.Adapt<Product>();
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Adapt<ProductResponseDTO>();
        }

        public async Task UpdateProductAsync(int id , ProductUpdateDTO productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("Product not found.");

            productDto.Adapt(product);
            product.UpdatedAt = DateTime.UtcNow;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("Product not found.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
