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
        [Key]
        public int OrderID { get; set; }

        [Required]
        public string BuyerID { get; set; }
        public User Buyer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } // Pending, Shipped, Completed, Canceled

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Payment Payment { get; set; }
        public Shipping Shipping { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
        public Escrow Escrow { get; set; }
    }
}
