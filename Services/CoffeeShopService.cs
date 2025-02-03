using Microsoft.EntityFrameworkCore;
using CoffeeShopAPI.Models;
using System.Threading.Tasks;

public class CoffeeShopService
{
    private readonly CoffeeShopDbContext _context;

    public CoffeeShopService(CoffeeShopDbContext context)
    {
        _context = context;
    }

    // Create a new coffee shop
    public async Task<CoffeeShop> CreateCoffeeShopAsync(CoffeeShop coffeeShop)
    {
        var existingCoffeeShop = await _context.CoffeeShops
            .FirstOrDefaultAsync(cs => cs.Name == coffeeShop.Name);

        if (existingCoffeeShop != null)
        {
            throw new InvalidOperationException("Coffee shop with the same name already exists.");
        }

        _context.CoffeeShops.Add(coffeeShop);
        await _context.SaveChangesAsync();

        return coffeeShop;
    }

    // Get all coffee shops
    public async Task<IEnumerable<CoffeeShop>> GetAllCoffeeShopsAsync()
    {
        return await _context.CoffeeShops.ToListAsync();
    }

    // Get a coffee shop by ID
    public async Task<CoffeeShop> GetCoffeeShopByIdAsync(int id)
    {
        // return await _context.CoffeeShops.FindAsync(id);
         var coffeeShop = await _context.CoffeeShops.FindAsync(id);
        if (coffeeShop == null)
        {
            throw new InvalidOperationException("Coffee shop not found.");
        }
        return coffeeShop;
    }

    // Update a coffee shop
    public async Task UpdateCoffeeShopAsync(CoffeeShop coffeeShop)
    {
        var existingCoffeeShop = await _context.CoffeeShops.FindAsync(coffeeShop.Id);

        if (existingCoffeeShop == null)
        {
            throw new InvalidOperationException("Coffee shop not found.");
        }

        existingCoffeeShop.Name = coffeeShop.Name;
        existingCoffeeShop.OpeningTime = coffeeShop.OpeningTime;
        existingCoffeeShop.ClosingTime = coffeeShop.ClosingTime;
        existingCoffeeShop.Location = coffeeShop.Location;
        existingCoffeeShop.Rating = coffeeShop.Rating;

        await _context.SaveChangesAsync();
    }

    // Delete a coffee shop
    public async Task DeleteCoffeeShopAsync(int id)
    {
        var existingCoffeeShop = await _context.CoffeeShops.FindAsync(id);

        if (existingCoffeeShop == null)
        {
            throw new InvalidOperationException("Coffee shop not found.");
        }

        _context.CoffeeShops.Remove(existingCoffeeShop);
        await _context.SaveChangesAsync();
    }
}