using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string BuyerID { get; set; }
        public string Status { get; set; } // Pending, Shipped, Completed, Canceled
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual AppUser Buyer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual Escrow Escrow { get; set; }
    }
}
