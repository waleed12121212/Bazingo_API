using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Auction
{
    public class CreateAuctionDto
    {
        public int ProductId { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime EndTime { get; set; }
    }
}
