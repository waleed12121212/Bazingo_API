using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class ComplaintResponseDTO
    {
        public int ComplaintID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int OrderID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Open, InProgress, Resolved
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
