using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } // CreditCard, COD, PayPal

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } // Pending, Completed, Failed

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal PaymentAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
