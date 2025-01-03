using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Auction
{
    public class PlaceBidDto
    {
        public int AuctionId { get; set; }
        public decimal BidAmount { get; set; }
    }
}
