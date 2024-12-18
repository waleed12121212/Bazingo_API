using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class OrderCreateDTO
    {
        public string BuyerID { get; set; } // FK to User
        public List<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}
