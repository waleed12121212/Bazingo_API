using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Order
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
        public string ShippingAddress { get; set; }
    }

}
