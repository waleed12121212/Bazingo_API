using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Complaint
{
    public class UpdateComplaintStatusDto
    {
        public int ComplaintId { get; set; }
        public string Status { get; set; } // Open, InProgress, Resolved
    }
}
