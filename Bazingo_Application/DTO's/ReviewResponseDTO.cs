using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class ReviewResponseDTO
    {
        public int ReviewID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
