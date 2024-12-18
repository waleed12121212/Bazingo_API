using Bazingo_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Interfaces
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<Auction> GetAuctionWithBidsAsync(int auctionId);
        Task<Bid> GetHighestBidAsync(int auctionId);
        Task<IEnumerable<Auction>> GetActiveAuctionsAsync( );
    }
}
