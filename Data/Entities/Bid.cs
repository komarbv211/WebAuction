using System;

namespace Data.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public Lot? Lot { get; set; }
        public int Amount { get; set; }
        public DateTime BidTime { get; set; }
        public string? BidderId { get; set; }
    }
}
