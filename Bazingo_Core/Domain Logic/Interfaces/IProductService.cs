using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts( );
        Task<ProductDto> GetProductById(int productId);
        Task<bool> CreateProduct(string sellerId , CreateProductDto dto);
        Task<bool> UpdateProduct(string sellerId , UpdateProductDto dto);
        Task<bool> DeleteProduct(int productId);
        Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<ProductDto>> SearchProducts(string keyword);
        Task<IEnumerable<ProductDto>> GetSellerProducts(string sellerId);
    }
}
