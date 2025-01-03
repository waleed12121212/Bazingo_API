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
        public int BidID { get; set; }
        public int AuctionID { get; set; }
        public string UserID { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Auction Auction { get; set; }
        public virtual AppUser User { get; set; }
    }
}
