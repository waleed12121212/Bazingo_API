using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Product Product { get; set; }
        public virtual AppUser User { get; set; }
    }
}
