using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Auction
    {
        [Key]
        public int AuctionID { get; set; }

        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal StartPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? WinnerID { get; set; }
        public User Winner { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public ICollection<Bid> Bids { get; set; }
    }
}
