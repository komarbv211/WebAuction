namespace WebAuction.Entities
{
    public class Lot
    {
        public int Id { get; set; }

        // Основні характеристики продукту
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public bool Archived { get; set; }  
        public Category? Category { get; set; }

        // Аукціонні властивості
        public decimal LastRate { get; set; }
        public int RateStep { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime StartOfBidding { get; set; }
        public int BidCount { get; set; }
        public bool IsAuctionActive { get; set; }
        public decimal HighestBid { get; set; }

        // Додаткові властивості
        public decimal? SellerMinPrice { get; set; }
        public decimal? MinBidIncrement { get; set; }

        // Колекція ставок на продукт
        public ICollection<Bid>? Bids { get; set; }
    }
}
