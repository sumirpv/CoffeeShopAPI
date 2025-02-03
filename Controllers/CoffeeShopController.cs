using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.Models;
[ApiController]
[Route("api/[controller]")]
public class CoffeeShopController : ControllerBase
{
    private readonly CoffeeShopService _coffeeShopService;

    public CoffeeShopController(CoffeeShopService coffeeShopService)
    {
        _coffeeShopService = coffeeShopService;
    }

    // Create a new coffee shop
    [HttpPost]
    public async Task<IActionResult> CreateCoffeeShopAsync([FromBody]CreateCoffeeShopRequest request)
    {
         var coffeeShop = new CoffeeShop
        {
            Name = request.Name,
            OpeningTime = request.OpeningTime,
            ClosingTime = request.ClosingTime,
            Location = request.Location,
            Rating = request.Rating
        };

        var createdCoffeeShop = await _coffeeShopService.CreateCoffeeShopAsync(coffeeShop);
        return Ok(createdCoffeeShop);
    }

    // Get all coffee shops
    [HttpGet]
    public async Task<IActionResult> GetAllCoffeeShopsAsync()
    {
        var coffeeShops = await _coffeeShopService.GetAllCoffeeShopsAsync();
        return Ok(coffeeShops);
    }

    // Get a coffee shop by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffeeShopByIdAsync(int id)
    {
         try
        {
            var coffeeShop = await _coffeeShopService.GetCoffeeShopByIdAsync(id);
            if (coffeeShop == null)
            {
                return NotFound("Coffee shop not found.");
            }

            return Ok(coffeeShop);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // Update a coffee shop
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoffeeShopAsync(int id, [FromBody]UpdateCoffeeShopRequest request)
    {
        var updatedCoffeeShop = new CoffeeShop
            {
                Id = id,
                Name = request.Name,
                OpeningTime = request.OpeningTime,
                ClosingTime = request.ClosingTime,
                Location = request.Location,
                Rating = request.Rating
            };

        await _coffeeShopService.UpdateCoffeeShopAsync(updatedCoffeeShop);

        return Ok(updatedCoffeeShop);
    }

    // Delete a coffee shop
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoffeeShopAsync(int id)
    {
        await _coffeeShopService.DeleteCoffeeShopAsync(id);
        return NoContent();
    }
}