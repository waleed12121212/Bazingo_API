using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Review
{
    public class AddReviewDto
    {
        public int ProductId { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string Comment { get; set; }
    }
}
