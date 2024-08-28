using AutoMapper;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BidService : IBidService
    {
        private readonly AuctionDbContext _context;
        private readonly IMapper _mapper;

        public BidService(AuctionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> PlaceBid(int lotId, int amount, string userId)
        {
            var lot = await _context.Lots.Include(l => l.Bids).FirstOrDefaultAsync(l => l.Id == lotId);

            if (lot == null || amount <= lot.HighestBid || amount - lot.HighestBid < lot.RateStep)
            {
                return false;
            }

            var bidUpdated = await UpdateOrCreateBidAsync(lotId, amount, userId);
            if (bidUpdated)
            {
                lot.HighestBid = amount;
                lot.BidCount++;
                await _context.SaveChangesAsync();
            }

            return bidUpdated;
        }
        private async Task<bool> UpdateOrCreateBidAsync(int lotId, int amount, string userId)
        {
            var existingBid = await _context.Bids.FirstOrDefaultAsync(b => b.LotId == lotId && b.BidderId == userId);

            if (existingBid != null)
            {
                existingBid.Amount = amount;
                existingBid.BidTime = DateTime.Now;
            }
            else
            {
                var bid = new Bid
                {
                    LotId = lotId,
                    Amount = amount,
                    BidTime = DateTime.Now,
                    BidderId = userId
                };

                _context.Bids.Add(bid);
            }

            return true;
        }
        public async Task<bool> DeleteBidAsync(int lotId, string userId)
        {
            var existingBid = await _context.Bids.FirstOrDefaultAsync(b => b.LotId == lotId && b.BidderId == userId);

            if (existingBid == null)
            {
                return false; 
            }

            _context.Bids.Remove(existingBid);
            await _context.SaveChangesAsync();

            return true; 
        }

    }
}
