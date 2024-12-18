using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.Mapping_Profiles
{
    public static class ProductMappingProfile
    {
        public static void RegisterMappings( )
        {
            TypeAdapterConfig<Product , ProductResponseDTO>.NewConfig()
                .Map(dest => dest.SellerName , src => $"{src.Seller.FirstName} {src.Seller.LastName}");

            TypeAdapterConfig<ProductCreateDTO , Product>.NewConfig();
            TypeAdapterConfig<ProductUpdateDTO , Product>.NewConfig();
        }
    }
}
