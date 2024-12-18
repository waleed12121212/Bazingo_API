using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; } // Buyer, Seller, Admin
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int NumericId { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>();
        public ICollection<Bid> Bids { get; set; } = new HashSet<Bid>();
        public ICollection<Auction> WonAuctions { get; set; } = new HashSet<Auction>();
    }
}
