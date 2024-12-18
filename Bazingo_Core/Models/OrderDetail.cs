using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Required]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1 , int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal PricePerUnit { get; set; }

        [Required]
        public decimal Subtotal { get; set; }
    }
}
