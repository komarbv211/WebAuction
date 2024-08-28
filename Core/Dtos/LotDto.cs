using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class LotDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool Archived { get; set; }
        public decimal LastRate { get; set; }
        public int RateStep { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime StartOfBidding { get; set; }
        public int BidCount { get; set; }
        public bool IsAuctionActive
        {
            get
            {
                return StartOfBidding.Date == DateTime.Now.Date;
            }
        }
        public decimal HighestBid { get; set; }
        public decimal? SellerMinPrice { get; set; }
        public decimal? MinBidIncrement { get; set; }
    }
}
