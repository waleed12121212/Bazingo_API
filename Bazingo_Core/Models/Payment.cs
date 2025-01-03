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
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public string PaymentMethod { get; set; } // CreditCard, COD, PayPal
        public string Status { get; set; } // Pending, Completed, Failed
        public decimal PaymentAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Order Order { get; set; }
    }
}
