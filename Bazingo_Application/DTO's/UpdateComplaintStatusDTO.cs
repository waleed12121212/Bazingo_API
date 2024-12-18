using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class UpdateComplaintStatusDTO
    {
        [Required]
        [RegularExpression("^(Open|InProgress|Resolved)$" , ErrorMessage = "Status must be Open, InProgress, or Resolved.")]
        public string Status { get; set; }
    }
}
