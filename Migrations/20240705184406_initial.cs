using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RateStep = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StartPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { 1, 550m, new DateTime(2024, 6, 30, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(290), 1, null, 1 },
                    { 2, 600m, new DateTime(2024, 7, 1, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(301), 3, null, 1 },
                    { 3, 700m, new DateTime(2024, 7, 2, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(306), 2, null, 1 }
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
                columns: new[] { "Id", "BidCount", "CategoryId", "Description", "EndTime", "HighestBid", "IsAuctionActive", "LastRate", "MinBidIncrement", "Name", "Quantity", "RateStep", "SellerMinPrice", "StartPrice" },
                values: new object[,]
                {
                    { 1, 0, 1, "Latest model", new DateTime(2024, 7, 12, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(97), 0m, true, 650m, 50m, "iPhone X", 5, 10, null, 500m },
                    { 2, 0, 2, "Strength training", new DateTime(2024, 7, 10, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(195), 0m, true, 45.5m, 5m, "PowerBall", 3, 5, null, 20m },
                    { 3, 0, 3, "Comfortable sportswear", new DateTime(2024, 7, 8, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(201), 0m, true, 189m, 10m, "Nike T-Shirt", 3, 15, null, 50m },
                    { 4, 0, 1, "Newest model", new DateTime(2024, 7, 15, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(207), 0m, true, 1200m, 100m, "Samsung S23", 0, 50, null, 1000m },
                    { 5, 0, 6, "Toys for kids", new DateTime(2024, 7, 9, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(212), 0m, true, 50m, 2m, "Air Ball", 0, 5, null, 10m },
                    { 6, 0, 1, "Powerful laptop", new DateTime(2024, 7, 19, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(220), 0m, true, 2300m, 200m, "MacBook Pro 2019", 23, 100, null, 2000m },
                    { 7, 0, 2, "Older model", new DateTime(2024, 7, 7, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(226), 0m, true, 440m, 10m, "Samsung S4", 0, 20, null, 100m }
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
