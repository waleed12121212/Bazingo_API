using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Order
{
    public class UpdateOrderStatusDto
    {
        public int OrderId { get; set; }
        public string Status { get; set; } // Pending, Shipped, Completed, Canceled
    }
}
