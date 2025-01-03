using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryID == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            return await _dbSet.Where(p => p.ProductName.Contains(keyword) || p.Description.Contains(keyword)).ToListAsync();
        }
    }
}
