using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    LastRate = table.Column<int>(type: "int", nullable: false),
                    RateStep = table.Column<int>(type: "int", nullable: false),
                    StartPrice = table.Column<int>(type: "int", nullable: false),
                    StartOfBidding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidCount = table.Column<int>(type: "int", nullable: false),
                    HighestBid = table.Column<int>(type: "int", nullable: false),
                    SellerMinPrice = table.Column<int>(type: "int", nullable: true),
                    MinBidIncrement = table.Column<int>(type: "int", nullable: true)
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
                    LotId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Archived", "BidCount", "CategoryId", "Description", "HighestBid", "ImageUrl", "LastRate", "MinBidIncrement", "Name", "Quantity", "RateStep", "SellerMinPrice", "StartOfBidding", "StartPrice" },
                values: new object[,]
                {
                    { 1, false, 0, 1, "Latest model", 0, "https://cdn.new-brz.net/app/public/models/MQAG2/large/w/180413170205345780.webp", 650, 50, "iPhone X", 5, 10, null, new DateTime(2024, 7, 18, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3172), 500 },
                    { 2, false, 0, 2, "Strength training", 0, "https://powerball.ua/content/images/46/480x480l50nn0/kystovyi-trenazher-powerball-e-titan-pro-electric-start-85723670147321.jpg", 45, 5, "PowerBall", 3, 5, null, new DateTime(2024, 7, 22, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3338), 20 },
                    { 3, false, 0, 3, "Comfortable sportswear", 0, "https://lh5.googleusercontent.com/proxy/mMh-P0oMHtmHlosJf4VKCNQEIq6201qQb8iaWP39c24dFaWNo8rM8EOVQevKbhc8vOrMbmCUJYR_PEfdrx4MVqd5dlIggBUvJmUSTKO2JnI", 189, 10, "Nike T-Shirt", 3, 15, null, new DateTime(2024, 7, 20, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3343), 50 },
                    { 4, false, 0, 1, "Newest model", 0, "https://hotline.ua/img/tx/370/3708775135.jpg", 1200, 100, "Samsung S23", 0, 50, null, new DateTime(2024, 7, 27, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3348), 1000 },
                    { 5, false, 0, 6, "Toys for kids", 0, "https://sport.qc.ca/wp-content/uploads/2021/01/dsl-original-images/loi_air18_18_air_ball_ballon_air_18_1486249200_1488836710.jpg", 50, 2, "Air Ball", 0, 5, null, new DateTime(2024, 7, 21, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3353), 10 },
                    { 6, false, 0, 1, "Powerful laptop", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyR7bUxH63AoIF2_TESOi2pgOgdEn5x4qAYA&s", 2300, 200, "MacBook Pro 2019", 23, 100, null, new DateTime(2024, 7, 31, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3513), 2000 },
                    { 7, false, 0, 2, "Older model", 0, "https://remont2.lvivservice.com.ua/upload/iblock/b39/S4.png", 440, 10, "Samsung S4", 0, 20, null, new DateTime(2024, 7, 19, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3521), 100 }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Amount", "BidTime", "BidderId", "LotId" },
                values: new object[,]
                {
                    { 1, 550, new DateTime(2024, 7, 12, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3635), 1, 1 },
                    { 2, 600, new DateTime(2024, 7, 13, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3649), 3, 1 },
                    { 3, 700, new DateTime(2024, 7, 14, 20, 3, 32, 660, DateTimeKind.Local).AddTicks(3654), 2, 1 }
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
