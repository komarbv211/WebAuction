using WebAuction.Entityes;

namespace WebAuction.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Lot? Lot { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public int BidderId { get; set; }
    }
}
