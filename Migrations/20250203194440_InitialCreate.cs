using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coffee_shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coffee_shops", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "coffee_shops",
                columns: new[] { "Id", "ClosingTime", "Location", "Name", "OpeningTime", "Rating" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 22, 0, 0, 0), "New York, NY", "Central Perk", new TimeSpan(0, 8, 0, 0, 0), 4.5m },
                    { 2, new TimeSpan(0, 21, 0, 0, 0), "San Francisco, CA", "Java House", new TimeSpan(0, 15, 30, 0, 0), 4.0m },
                    { 3, new TimeSpan(0, 18, 0, 0, 0), "Los Angeles, CA", "The Coffee Bean", new TimeSpan(0, 6, 0, 0, 0), 4.7m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coffee_shops");
        }
    }
}
