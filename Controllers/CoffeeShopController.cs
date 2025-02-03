using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class CoffeeShopController : ControllerBase
{
    private readonly CoffeeShopService _coffeeShopService;

    public CoffeeShopController(CoffeeShopService coffeeShopService)
    {
        _coffeeShopService = coffeeShopService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoffeeShopAsync([FromBody] CreateCoffeeShopRequest request)
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

    [HttpGet]
    public async Task<IActionResult> GetAllCoffeeShopsAsync()
    {
        var coffeeShops = await _coffeeShopService.GetAllCoffeeShopsAsync();
        return Ok(coffeeShops.Select(shop => new
        {
            shop.Id,
            shop.Name,
            shop.OpeningTime,
            shop.ClosingTime,
            shop.Location,
            shop.Rating,
            IsOpen = shop.IsOpen()
        }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffeeShopByIdAsync(int id)
    {
        var coffeeShop = await _coffeeShopService.GetCoffeeShopByIdAsync(id);
        if (coffeeShop == null)
        {
            return NotFound("Coffee shop not found.");
        }
        return Ok(new
        {
            coffeeShop.Id,
            coffeeShop.Name,
            coffeeShop.OpeningTime,
            coffeeShop.ClosingTime,
            coffeeShop.Location,
            coffeeShop.Rating,
            IsOpen = coffeeShop.IsOpen()
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoffeeShopAsync(int id, [FromBody] UpdateCoffeeShopRequest request)
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
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoffeeShopAsync(int id)
    {
        await _coffeeShopService.DeleteCoffeeShopAsync(id);
        return NoContent();
    }
}