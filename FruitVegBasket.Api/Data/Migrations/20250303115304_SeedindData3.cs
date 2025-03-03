using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitVegBasket.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedindData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BgColor",
                value: "#e1f1e7");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BgColor",
                value: "#d0f200");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BgColor",
                value: "#e1f1e7");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BgColor",
                value: "#dad1f9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BgColor",
                value: "#d0f200");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BgColor",
                value: "#ea978d");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BgColor",
                value: "#ea978d");

            migrationBuilder.UpdateData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BgColor",
                value: "#7fbdc7");
        }
    }
}
