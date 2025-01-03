using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IAuctionService
    {
        Task<bool> CreateAuction(CreateAuctionDto dto);
        Task<AuctionDto> GetAuctionDetails(int auctionId);
        Task<bool> PlaceBid(string userId , PlaceBidDto dto);
        Task<IEnumerable<PlaceBidDto>> GetAuctionBids(int auctionId);
        Task<bool> EndAuction(int auctionId);
        Task<IEnumerable<AuctionDto>> AdminGetAllAuctions( );
    }
}
