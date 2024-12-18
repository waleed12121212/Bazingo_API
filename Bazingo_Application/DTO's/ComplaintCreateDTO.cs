using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class ComplaintCreateDTO
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        [StringLength(500 , ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
    }
}
