using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Cart
{
    public class UpdateCartItemQuantityDto
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
