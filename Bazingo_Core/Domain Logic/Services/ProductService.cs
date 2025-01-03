using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts( )
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductID ,
                ProductName = p.ProductName ,
                Description = p.Description ,
                Price = p.Price ,
                Quantity = p.Quantity
            });
        }

        public async Task<bool> CreateProduct(string sellerId , CreateProductDto dto)
        {
            var product = new Product
            {
                SellerID = sellerId ,
                ProductName = dto.ProductName ,
                Description = dto.Description ,
                Price = dto.Price ,
                Quantity = dto.Quantity ,
                CategoryID = dto.CategoryId
            };

            await _unitOfWork.Products.AddAsync(product);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
