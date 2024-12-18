using Bazingo_Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync( );
        Task<ProductResponseDTO> GetProductByIdAsync(int id);
        Task<ProductResponseDTO> CreateProductAsync(ProductCreateDTO productDto);
        Task UpdateProductAsync(int id , ProductUpdateDTO productDto);
        Task DeleteProductAsync(int id);
    }
}
