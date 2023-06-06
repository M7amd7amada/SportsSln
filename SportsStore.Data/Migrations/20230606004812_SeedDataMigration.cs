using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PorductId", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Watersports", "A boat for one person", "Kayak", 275m },
                    { 2L, "Chess", "Gold-plated, diamond-studded King", "Bling-Bling King", 1200m },
                    { 3L, "Chess", "A fun game for the family", "Human Chess Board", 75m },
                    { 4L, "Chess", "Secretly give your opponent a disadvantage", "Unsteady Chair", 29.95m },
                    { 5L, "Chess", "Improve brain efficiency by 75%", "Thinking Cap", 16m },
                    { 6L, "Soccer", "Give your playing field a professional touch", "Corner Flags", 34.95m },
                    { 7L, "Soccer", "FIFA-approved size and weight", "Soccer Ball", 19.50m },
                    { 8L, "Watersports", "Protective and fashionable", "Lifejacket", 48.95m },
                    { 9L, "Soccer", "Flat-packed 35,000-seat stadium", "Stadium", 79500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PorductId",
                keyValue: 9L);
        }
    }
}
