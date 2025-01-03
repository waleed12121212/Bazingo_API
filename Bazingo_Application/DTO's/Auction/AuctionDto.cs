using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Auction
{
    public class AuctionDto
    {
        public int AuctionId { get; set; }
        public string ProductName { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime EndTime { get; set; }
        public string WinnerName { get; set; }
    }
}
