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
        public int ShippingID { get; set; }
        public int OrderID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string TrackingNumber { get; set; }
        public string ShippingStatus { get; set; } // Pending, InTransit, Delivered
        public string ShippingMethod { get; set; }
        public int ZoneID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual Zone Zone { get; set; }
        public virtual Order Order { get; set; }
    }
}
