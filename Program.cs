using Microsoft.EntityFrameworkCore;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Services;

namespace CoffeeShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CoffeeShopDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<CoffeeShopService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapControllers();
            app.Run("http://localhost:5001");

        }
    }
}