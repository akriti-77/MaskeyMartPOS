using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickMartPOSWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionItems_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Grocery", "Rice (1 kg)", 1.20m },
                    { 2, "Grocery", "Flour (1 kg)", 0.90m },
                    { 3, "Grocery", "Sugar (1 kg)", 1.10m },
                    { 4, "Grocery", "Cooking Oil (1L)", 3.50m },
                    { 5, "Grocery", "Salt (1 kg)", 0.50m },
                    { 6, "Grocery", "Lentils (1 kg)", 1.80m },
                    { 7, "Grocery", "Turmeric (100g)", 0.60m },
                    { 8, "Grocery", "Tea (100g)", 1.50m },
                    { 9, "Snacks", "Biscuits (pack)", 1.00m },
                    { 10, "Snacks", "Potato Chips (pack)", 1.20m },
                    { 11, "Snacks", "Instant Noodles", 0.50m },
                    { 12, "Snacks", "Chocolate Bar", 1.50m },
                    { 13, "Beverages", "Soft Drink (500ml)", 1.00m },
                    { 14, "Beverages", "Juice (1L)", 2.00m },
                    { 15, "Beverages", "Beer", 10.00m },
                    { 16, "Beverages", "Vodka", 50.00m },
                    { 17, "Beverages", "Wine", 30.00m },
                    { 18, "Dairy", "Milk (1L)", 1.20m },
                    { 19, "Dairy", "Butter (200g)", 2.50m },
                    { 20, "Dairy", "Cheese (200g)", 3.00m },
                    { 21, "Dairy", "Yogurt (200g)", 0.80m },
                    { 22, "Dairy", "Bread (loaf)", 1.00m },
                    { 23, "Household", "Soap (bar)", 0.80m },
                    { 24, "Household", "Detergent (500g)", 2.00m },
                    { 25, "Household", "Toothpaste (100g)", 1.50m },
                    { 26, "Household", "Shampoo (200ml)", 3.00m },
                    { 27, "Household", "Toilet Paper (roll)", 0.70m },
                    { 28, "Personal Care", "Toothbrush", 1.00m },
                    { 29, "Personal Care", "Hair Oil (100ml)", 2.00m },
                    { 30, "Personal Care", "Deodorant", 2.50m },
                    { 31, "Stationery", "Notebook", 1.50m },
                    { 32, "Stationery", "Pen", 0.50m },
                    { 33, "Stationery", "Batteries (AA, pack of 2)", 2.00m },
                    { 34, "Stationery", "Lighter", 0.80m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_ProductId",
                table: "TransactionItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_TransactionId",
                table: "TransactionItems",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
