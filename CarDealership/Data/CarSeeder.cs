using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Data
{
    public static class CarSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CarDbContext>();
            if (await db.Vehicles.AnyAsync())
            {
                return;
            }

            await db.Vehicles.AddRangeAsync(
                  new Vehicle
                  {
                      Make = "Toyota",
                      Model = "Corolla",
                      Year = 2021,
                      FuelType = "Petrol",
                      Condition = "Excellent",
                      Color = "White",
                      Description = "Reliable and fuel-efficient sedan.",
                      Price = 250000,
                      IsAvailable = true,
                      DateAdded = DateTime.Now
                  },
                  new Vehicle
                  {
                      Make = "Ford",
                      Model = "Ranger",
                      Year = 2020,
                      FuelType = "Diesel",
                      Condition = "Good",
                      Color = "Blue",
                      Description = "Strong double cab with off-road capability.",
                      Price = 480000,
                      IsAvailable = true,
                      DateAdded = DateTime.Now
                  },
                  new Vehicle
                  {
                      Make = "Volkswagen",
                      Model = "Golf GTI",
                      Year = 2019,
                      FuelType = "Petrol",
                      Condition = "Very Good",
                      Color = "Red",
                      Description = "Sporty hatchback with turbocharged engine.",
                      Price = 390000,
                      IsAvailable = false,
                      DateAdded = DateTime.Now
                  },
                  new Vehicle
                  {
                      Make = "BMW",
                      Model = "X5",
                      Year = 2022,
                      FuelType = "Diesel",
                      Condition = "New",
                      Color = "Black",
                      Description = "Luxury SUV with advanced safety features.",
                      Price = 950000,
                      IsAvailable = true,
                      DateAdded = DateTime.Now
                  },
                  new Vehicle
                  {
                      Make = "Nissan",
                      Model = "Navara",
                      Year = 2021,
                      FuelType = "Diesel",
                      Condition = "Excellent",
                      Color = "Silver",
                      Description = "Modern bakkie suitable for work and leisure.",
                      Price = 520000,
                      IsAvailable = true,
                      DateAdded = DateTime.Now
                  }
              );

            db.SaveChanges();
        }
    }

}