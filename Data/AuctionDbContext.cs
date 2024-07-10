using Microsoft.EntityFrameworkCore;
using WebAuction.Entities;

namespace WebAuction.Data
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebAuction;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Sport" },
                new Category { Id = 3, Name = "Fashion" },
                new Category { Id = 4, Name = "Home & Garden" },
                new Category { Id = 5, Name = "Transport" },
                new Category { Id = 6, Name = "Toys & Hobbies" },
                new Category { Id = 7, Name = "Musical Instruments" },
                new Category { Id = 8, Name = "Art" },
                new Category { Id = 9, Name = "Other" }
            });

            modelBuilder.Entity<Lot>().HasData(new List<Lot>
            {
                new Lot { Id = 1, Name = "iPhone X",         Description = "Latest model",           LastRate = 650,  RateStep = 10, Quantity = 5,  CategoryId = 1, StartPrice = 500,  StartOfBidding = DateTime.Now.AddDays(1), BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 50 },
                new Lot { Id = 2, Name = "PowerBall",        Description = "Strength training",      LastRate = 45.5M,RateStep = 5,  Quantity = 3,  CategoryId = 2, StartPrice = 20,   StartOfBidding = DateTime.Now.AddDays(5), BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 5 },
                new Lot { Id = 3, Name = "Nike T-Shirt",     Description = "Comfortable sportswear", LastRate = 189,  RateStep = 15, Quantity = 3,  CategoryId = 3, StartPrice = 50,   StartOfBidding = DateTime.Now.AddDays(3), BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 10 },
                new Lot { Id = 4, Name = "Samsung S23",      Description = "Newest model",           LastRate = 1200, RateStep = 50, Quantity = 0,  CategoryId = 1, StartPrice = 1000, StartOfBidding = DateTime.Now.AddDays(10),BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 100 },
                new Lot { Id = 5, Name = "Air Ball",         Description = "Toys for kids",          LastRate = 50,   RateStep = 5,  Quantity = 0,  CategoryId = 6, StartPrice = 10,   StartOfBidding = DateTime.Now.AddDays(4), BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 2 },
                new Lot { Id = 6, Name = "MacBook Pro 2019", Description = "Powerful laptop",        LastRate = 2300, RateStep = 100,Quantity = 23, CategoryId = 1, StartPrice = 2000, StartOfBidding = DateTime.Now.AddDays(14),BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 200 },
                new Lot { Id = 7, Name = "Samsung S4",       Description = "Older model",            LastRate = 440,  RateStep = 20, Quantity = 0,  CategoryId = 2, StartPrice = 100,  StartOfBidding = DateTime.Now.AddDays(2), BidCount = 0, IsAuctionActive = true, HighestBid = 0, MinBidIncrement = 10 },
            });
            modelBuilder.Entity<Bid>().HasData(new List<Bid>
            {
                new Bid { Id = 1, ProductId = 1, Amount = 550, BidTime = DateTime.Now.AddDays(-5), BidderId = 1 },
                new Bid { Id = 2, ProductId = 1, Amount = 600, BidTime = DateTime.Now.AddDays(-4), BidderId = 3 },
                new Bid { Id = 3, ProductId = 1, Amount = 700, BidTime = DateTime.Now.AddDays(-3), BidderId = 2 },
            });
        }
    }
}
