using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Complaint
{
    public class ComplaintDto
    {
        public int ComplaintId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Open, InProgress, Resolved
        public DateTime CreatedAt { get; set; }
    }
}
