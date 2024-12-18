using Bazingo_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsBySellerAsync(string sellerId);
        Task<IEnumerable<Product>> SearchProductsAsync(string keyword , decimal? minPrice , decimal? maxPrice);
        Task<bool> IsProductInStockAsync(int productId);
    }
}
