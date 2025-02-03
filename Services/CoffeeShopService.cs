using Microsoft.EntityFrameworkCore;
using CoffeeShopAPI.Models;


namespace CoffeeShopAPI.Services
{
    public class CoffeeShopService
    {
        private readonly CoffeeShopDbContext _context;

        public CoffeeShopService(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public async Task<CoffeeShop> CreateCoffeeShopAsync(CoffeeShop coffeeShop)
        {
            _context.CoffeeShops.Add(coffeeShop);
            await _context.SaveChangesAsync();
            return coffeeShop;
        }

        public async Task<IEnumerable<CoffeeShop>> GetAllCoffeeShopsAsync()
        {
            return await _context.CoffeeShops.ToListAsync();
        }

        public async Task<CoffeeShop?> GetCoffeeShopByIdAsync(int id)
        {
            return await _context.CoffeeShops.FindAsync(id);
        }

        public async Task UpdateCoffeeShopAsync(CoffeeShop coffeeShop)
        {
            _context.CoffeeShops.Update(coffeeShop);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoffeeShopAsync(int id)
        {
            var coffeeShop = await _context.CoffeeShops.FindAsync(id);
            if (coffeeShop != null)
            {
                _context.CoffeeShops.Remove(coffeeShop);
                await _context.SaveChangesAsync();
            }
        }
    }
}