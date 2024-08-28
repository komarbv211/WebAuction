using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data.Data
{
    public class AuctionDbContext : IdentityDbContext<User>
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
        {
        }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Order> Orders { get; set; }

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
                new Lot { Id = 1, Name = "iPhone X",        ImageUrl ="https://cdn.new-brz.net/app/public/models/MQAG2/large/w/180413170205345780.webp",  Description = "Latest model",           LastRate = 650,  RateStep = 10, Quantity = 5,  CategoryId = 1, StartPrice = 500,  StartOfBidding = DateTime.Now.AddDays(1), BidCount = 0, HighestBid = 0, MinBidIncrement = 50 },
                new Lot { Id = 2, Name = "PowerBall",       ImageUrl ="https://powerball.ua/content/images/46/480x480l50nn0/kystovyi-trenazher-powerball-e-titan-pro-electric-start-85723670147321.jpg",  Description = "Strength training",      LastRate = 45,RateStep = 5,  Quantity = 3,  CategoryId = 2, StartPrice = 20,   StartOfBidding = DateTime.Now.AddDays(5), BidCount = 0, HighestBid = 0, MinBidIncrement = 5 },
                new Lot { Id = 3, Name = "Nike T-Shirt",    ImageUrl ="https://lh5.googleusercontent.com/proxy/mMh-P0oMHtmHlosJf4VKCNQEIq6201qQb8iaWP39c24dFaWNo8rM8EOVQevKbhc8vOrMbmCUJYR_PEfdrx4MVqd5dlIggBUvJmUSTKO2JnI",  Description = "Comfortable sportswear", LastRate = 189,  RateStep = 15, Quantity = 3,  CategoryId = 3, StartPrice = 50,   StartOfBidding = DateTime.Now.AddDays(3), BidCount = 0, HighestBid = 0, MinBidIncrement = 10 },
                new Lot { Id = 4, Name = "Samsung S23",     ImageUrl ="https://hotline.ua/img/tx/370/3708775135.jpg",  Description = "Newest model",           LastRate = 1200, RateStep = 50, Quantity = 0,  CategoryId = 1, StartPrice = 1000, StartOfBidding = DateTime.Now.AddDays(10),BidCount = 0, HighestBid = 0, MinBidIncrement = 100 },
                new Lot { Id = 5, Name = "Air Ball",        ImageUrl ="https://sport.qc.ca/wp-content/uploads/2021/01/dsl-original-images/loi_air18_18_air_ball_ballon_air_18_1486249200_1488836710.jpg",  Description = "Toys for kids",          LastRate = 50,   RateStep = 5,  Quantity = 0,  CategoryId = 6, StartPrice = 10,   StartOfBidding = DateTime.Now.AddDays(4), BidCount = 0, HighestBid = 0, MinBidIncrement = 2 },
                new Lot { Id = 6, Name = "MacBook Pro 2019",ImageUrl ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyR7bUxH63AoIF2_TESOi2pgOgdEn5x4qAYA&s",  Description = "Powerful laptop",        LastRate = 2300, RateStep = 100,Quantity = 23, CategoryId = 1, StartPrice = 2000, StartOfBidding = DateTime.Now.AddDays(14),BidCount = 0, HighestBid = 0, MinBidIncrement = 200 },
                new Lot { Id = 7, Name = "Samsung S4",      ImageUrl ="https://remont2.lvivservice.com.ua/upload/iblock/b39/S4.png",  Description = "Older model",            LastRate = 440,  RateStep = 20, Quantity = 0,  CategoryId = 2, StartPrice = 100,  StartOfBidding = DateTime.Now.AddDays(2), BidCount = 0, HighestBid = 0, MinBidIncrement = 10 },
            });

            modelBuilder.Entity<Bid>().HasData(new List<Bid>
            {
                new Bid { Id = 1, LotId = 1, Amount = 550, BidTime = DateTime.Now.AddDays(-5), BidderId = "bb8959f7-f59a-4328-bbdb-8bfe439cd7f4" },
                new Bid { Id = 2, LotId = 1, Amount = 600, BidTime = DateTime.Now.AddDays(-4), BidderId = "bb8959f7-f59a-4328-bbdb-8bfe439cd7f4" },
                new Bid { Id = 3, LotId = 1, Amount = 700, BidTime = DateTime.Now.AddDays(-3), BidderId = "bb8959f7-f59a-4328-bbdb-8bfe439cd7f4"},
            });

        }
    }
}
