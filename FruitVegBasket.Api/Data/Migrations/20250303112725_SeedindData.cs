using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FruitVegBasket.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedindData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Credit", "Image", "Name", "ParentId" },
                values: new object[,]
                {
                    { (short)1, "Photo By <a href=\"", "apple.jpg", "Apple", (short)0 },
                    { (short)2, "Photo By <a href=\"", "banana.jpg", "Banana", (short)0 },
                    { (short)3, "Photo By <a href=\"", "carrot.jpg", "Carrot", (short)0 },
                    { (short)4, "Photo By <a href=\"", "broccoli.jpg", "Broccoli", (short)0 },
                    { (short)5, "Photo By <a href=\"", "milk.jpg", "Milk", (short)0 },
                    { (short)6, "Photo By <a href=\"", "cheese.jpg", "Cheese", (short)0 },
                    { (short)7, "Photo By <a href=\"", "eggs.jpg", "Eggs", (short)0 },
                    { (short)8, "Photo By <a href=\"", "chicken.jpg", "Chicken", (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Offer",
                columns: new[] { "Id", "BgColor", "Code", "Description", "Title", "isActive" },
                values: new object[,]
                {
                    { 1, "#dad1f9", "Frt30", "Enjoy upto 30% off on all fruits", "Upto 30% off", false },
                    { 2, "#7fbdc7", "VegB1G1", "Buy one get one free on selected vegetables", "Buy 1 Get 1 Free", false },
                    { 3, "#e1f1e7", "Dairy20", "Get 20% off on all dairy products", "20% off on Dairy", false },
                    { 4, "#e1f1e7", "EggMeat10", "Special discount on eggs and meat", "Special Discount", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offer",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
