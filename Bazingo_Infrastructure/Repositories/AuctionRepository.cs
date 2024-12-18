using Bazingo_Core.Interfaces;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Repositories
{
    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Auction> GetAuctionWithBidsAsync(int auctionId)
        {
            return await _context.Auctions
                .Include(a => a.Bids)
                .FirstOrDefaultAsync(a => a.AuctionID == auctionId);
        }

        public async Task<Bid> GetHighestBidAsync(int auctionId)
        {
            return await _context.Bids
                .Where(b => b.AuctionID == auctionId)
                .OrderByDescending(b => b.BidAmount)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetActiveAuctionsAsync( )
        {
            return await _context.Auctions
                .Where(a => a.EndTime > DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
