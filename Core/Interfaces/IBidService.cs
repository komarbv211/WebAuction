using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBidService
    {
        Task<bool> PlaceBid(int lotId, int amount, string userId);
        Task<bool> DeleteBidAsync(int lotId, string userId);
    }
}
