using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface ICartService
    {
        Task<bool> AddToCart(string userId , AddToCartDto dto);
        Task<bool> RemoveFromCart(int cartItemId);
        Task<IEnumerable<CartItemDto>> GetCartItems(string userId);
        Task<bool> UpdateCartItemQuantity(UpdateCartItemQuantityDto dto);
        Task<bool> ClearCart(string userId);
    }
}
