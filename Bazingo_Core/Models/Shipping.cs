using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingID { get; set; }

        [Required]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string TrackingNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShippingStatus { get; set; } // Pending, InTransit, Delivered

        [Required]
        public string ShippingMethod { get; set; }

        [Required]
        public int ZoneID { get; set; }
        public Zone Zone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
