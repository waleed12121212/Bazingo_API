using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public string UserID { get; set; }
        public int OrderID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Open, InProgress, Resolved
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual AppUser User { get; set; }
        public virtual Order Order { get; set; }
    }
}
