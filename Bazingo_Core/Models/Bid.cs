using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Models
{
    public class Bid
    {
        [Key]
        public int BidID { get; set; }

        [Required]
        public int AuctionID { get; set; }
        public Auction Auction { get; set; }

        [Required]
        public string UserID { get; set; }
        public User User { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue)]
        public decimal BidAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
