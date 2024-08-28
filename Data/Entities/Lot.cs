using System.Collections.Generic;
using System;
namespace Data.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public bool Archived { get; set; }
        public Category? Category { get; set; }

        // Аукціонні властивості
        public int LastRate { get; set; }
        public int RateStep { get; set; }
        public int StartPrice { get; set; }
        public DateTime StartOfBidding { get; set; }
        public int BidCount { get; set; }
        public int HighestBid { get; set; }

        // Додаткові властивості
        public int? SellerMinPrice { get; set; }
        public int? MinBidIncrement { get; set; }

        // Колекція ставок на продукт
        public ICollection<Bid>? Bids { get; set; }
    }
}
