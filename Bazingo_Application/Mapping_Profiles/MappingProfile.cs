using Bazingo_Application.DTO_s.Identity;
using Bazingo_Application.DTO_s.Product;
using Bazingo_Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.Mapping_Profiles
{
    public static class MappingProfile
    {
        public static void ConfigureMappings( )
        {
            TypeAdapterConfig<RegisterUserDto , AppUser>.NewConfig()
                .Map(dest => dest.UserName , src => src.Email);

            TypeAdapterConfig<Product , ProductDto>.NewConfig();
            TypeAdapterConfig<CreateProductDto , Product>.NewConfig();
            TypeAdapterConfig<UpdateProductDto , Product>.NewConfig();
        }
    }
}
