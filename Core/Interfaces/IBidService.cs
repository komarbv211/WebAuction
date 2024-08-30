using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBidService
    {
        Task<BidDto?> GetUserBidForLotAsync(int lotId, string userId);
        Task<bool> PlaceBid(int lotId, int amount, string userId);
        Task<bool> DeleteBidAsync(int lotId, string userId);
    }
}
