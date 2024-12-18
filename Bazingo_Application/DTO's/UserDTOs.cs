using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s
{
    public class UserResponseDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; } // Buyer, Seller, Admin
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
