using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class OrderResponseDTO
    {
        public int OrderID { get; set; }
        public string BuyerID { get; set; }
        public string BuyerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Shipped, Completed, Canceled
        public DateTime CreatedAt { get; set; }
    }
}
