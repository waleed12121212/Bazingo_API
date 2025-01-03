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
        public int AuctionID { get; set; }
        public int ProductID { get; set; }
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime EndTime { get; set; }
        public string? WinnerID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Product Product { get; set; }
        public virtual AppUser Winner { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
