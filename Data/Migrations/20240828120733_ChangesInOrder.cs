using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNotificationSent",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "BidTime",
                value: new DateTime(2024, 8, 23, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "BidTime",
                value: new DateTime(2024, 8, 24, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                column: "BidTime",
                value: new DateTime(2024, 8, 25, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 29, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 2, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 31, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 7, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 1, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 11, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 30, 15, 7, 31, 465, DateTimeKind.Local).AddTicks(1711));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNotificationSent",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "BidTime",
                value: new DateTime(2024, 8, 22, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "BidTime",
                value: new DateTime(2024, 8, 23, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                column: "BidTime",
                value: new DateTime(2024, 8, 24, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 28, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 1, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 30, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 6, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 31, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartOfBidding",
                value: new DateTime(2024, 9, 10, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartOfBidding",
                value: new DateTime(2024, 8, 29, 22, 2, 53, 322, DateTimeKind.Local).AddTicks(2702));
        }
    }
}
