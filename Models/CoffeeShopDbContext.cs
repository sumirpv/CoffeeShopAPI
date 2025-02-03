using Microsoft.EntityFrameworkCore;

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
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "data", "coffee_shops.db");
            options.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeShop>().ToTable("coffee_shops");
        }
    }
}