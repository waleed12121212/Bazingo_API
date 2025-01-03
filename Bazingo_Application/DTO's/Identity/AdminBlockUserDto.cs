using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Identity
{
    public class AdminBlockUserDto
    {
        public string UserId { get; set; }
        public bool IsBlocked { get; set; }
    }
}
