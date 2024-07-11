using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class Ititial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    LastRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RateStep = table.Column<int>(type: "int", nullable: false),
                    StartPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartOfBidding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidCount = table.Column<int>(type: "int", nullable: false),
                    IsAuctionActive = table.Column<bool>(type: "bit", nullable: false),
                    HighestBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellerMinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinBidIncrement = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Amount", "BidTime", "BidderId", "LotId", "ProductId" },
                values: new object[,]
                {
                    { 1, 550m, new DateTime(2024, 7, 5, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(379), 1, null, 1 },
                    { 2, 600m, new DateTime(2024, 7, 6, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(391), 3, null, 1 },
                    { 3, 700m, new DateTime(2024, 7, 7, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(396), 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Sport" },
                    { 3, "Fashion" },
                    { 4, "Home & Garden" },
                    { 5, "Transport" },
                    { 6, "Toys & Hobbies" },
                    { 7, "Musical Instruments" },
                    { 8, "Art" },
                    { 9, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "Archived", "BidCount", "CategoryId", "Description", "HighestBid", "ImageUrl", "IsAuctionActive", "LastRate", "MinBidIncrement", "Name", "Quantity", "RateStep", "SellerMinPrice", "StartOfBidding", "StartPrice" },
                values: new object[,]
                {
                    { 1, false, 0, 1, "Latest model", 0m, "https://cdn.new-brz.net/app/public/models/MQAG2/large/w/180413170205345780.webp", true, 650m, 50m, "iPhone X", 5, 10, null, new DateTime(2024, 7, 11, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(165), 500m },
                    { 2, false, 0, 2, "Strength training", 0m, "https://powerball.ua/content/images/46/480x480l50nn0/kystovyi-trenazher-powerball-e-titan-pro-electric-start-85723670147321.jpg", true, 45.5m, 5m, "PowerBall", 3, 5, null, new DateTime(2024, 7, 15, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(257), 20m },
                    { 3, false, 0, 3, "Comfortable sportswear", 0m, "https://lh5.googleusercontent.com/proxy/mMh-P0oMHtmHlosJf4VKCNQEIq6201qQb8iaWP39c24dFaWNo8rM8EOVQevKbhc8vOrMbmCUJYR_PEfdrx4MVqd5dlIggBUvJmUSTKO2JnI", true, 189m, 10m, "Nike T-Shirt", 3, 15, null, new DateTime(2024, 7, 13, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(263), 50m },
                    { 4, false, 0, 1, "Newest model", 0m, "https://hotline.ua/img/tx/370/3708775135.jpg", true, 1200m, 100m, "Samsung S23", 0, 50, null, new DateTime(2024, 7, 20, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(287), 1000m },
                    { 5, false, 0, 6, "Toys for kids", 0m, "https://sport.qc.ca/wp-content/uploads/2021/01/dsl-original-images/loi_air18_18_air_ball_ballon_air_18_1486249200_1488836710.jpg", true, 50m, 2m, "Air Ball", 0, 5, null, new DateTime(2024, 7, 14, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(295), 10m },
                    { 6, false, 0, 1, "Powerful laptop", 0m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyR7bUxH63AoIF2_TESOi2pgOgdEn5x4qAYA&s", true, 2300m, 200m, "MacBook Pro 2019", 23, 100, null, new DateTime(2024, 7, 24, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(303), 2000m },
                    { 7, false, 0, 2, "Older model", 0m, "https://remont2.lvivservice.com.ua/upload/iblock/b39/S4.png", true, 440m, 10m, "Samsung S4", 0, 20, null, new DateTime(2024, 7, 12, 20, 30, 47, 243, DateTimeKind.Local).AddTicks(309), 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_LotId",
                table: "Bids",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_CategoryId",
                table: "Lots",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
