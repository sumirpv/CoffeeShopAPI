using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CoffeeShopAPI.Models
{
    public class CoffeeShopDbContext : DbContext
    {
        public DbSet<CoffeeShop> CoffeeShops { get; set; }

        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Ensure the SQLite database path is properly set
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "data", "coffee_shops.db");
            options.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the CoffeeShop entity to the table "coffee_shops"
            modelBuilder.Entity<CoffeeShop>().ToTable("coffee_shops");

            // Seed the database with initial data
            modelBuilder.Entity<CoffeeShop>().HasData(
                new CoffeeShop
                {
                    Id = 1,
                    Name = "Central Perk",
                    OpeningTime = new TimeSpan(8, 0, 0),
                    ClosingTime = new TimeSpan(22, 0, 0),
                    Location = "New York, NY",
                    Rating = 4.5m
                },
                new CoffeeShop
                {
                    Id = 2,
                    Name = "Java House",
                    OpeningTime = new TimeSpan(15, 30, 0),
                    ClosingTime = new TimeSpan(21, 0, 0),
                    Location = "San Francisco, CA",
                    Rating = 4.0m
                },
                new CoffeeShop
                {
                    Id = 3,
                    Name = "The Coffee Bean",
                    OpeningTime = new TimeSpan(6, 0, 0),
                    ClosingTime = new TimeSpan(18, 0, 0),
                    Location = "Los Angeles, CA",
                    Rating = 4.7m
                }
            );
        }
    }
}