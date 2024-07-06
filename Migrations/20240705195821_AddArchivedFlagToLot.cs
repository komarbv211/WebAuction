using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class AddArchivedFlagToLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Lots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "BidTime",
                value: new DateTime(2024, 6, 30, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "BidTime",
                value: new DateTime(2024, 7, 1, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                column: "BidTime",
                value: new DateTime(2024, 7, 2, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 6, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8539) });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 10, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 8, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 15, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 9, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 19, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8693) });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Archived", "EndTime" },
                values: new object[] { false, new DateTime(2024, 7, 7, 22, 58, 20, 822, DateTimeKind.Local).AddTicks(8699) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Lots");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "BidTime",
                value: new DateTime(2024, 6, 30, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "BidTime",
                value: new DateTime(2024, 7, 1, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                column: "BidTime",
                value: new DateTime(2024, 7, 2, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndTime",
                value: new DateTime(2024, 7, 12, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "EndTime",
                value: new DateTime(2024, 7, 10, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "EndTime",
                value: new DateTime(2024, 7, 8, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4,
                column: "EndTime",
                value: new DateTime(2024, 7, 15, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5,
                column: "EndTime",
                value: new DateTime(2024, 7, 9, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6,
                column: "EndTime",
                value: new DateTime(2024, 7, 19, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7,
                column: "EndTime",
                value: new DateTime(2024, 7, 7, 21, 44, 6, 111, DateTimeKind.Local).AddTicks(226));
        }
    }
}
