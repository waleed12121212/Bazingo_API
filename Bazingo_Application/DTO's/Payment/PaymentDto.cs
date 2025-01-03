using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Payment
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Status { get; set; } // Pending, Completed, Failed
        public DateTime CreatedAt { get; set; }
    }
}
