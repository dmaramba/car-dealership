using CarDealership.Models;
using Microsoft.AspNetCore.Identity;

namespace CarDealership.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider services)
        {
            var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new string[] { "Administrator", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!roleResult.Succeeded)
                    {
                        var msg = string.Join("; ", roleResult.Errors.Select(e => $"{e.Code}:{e.Description}"));
                        throw new Exception($"Failed to create role '{role}': {msg}");
                    }
                }
            }

            var adminEmail = "admin@cars.local";
            var adminPassword = "Cars#123456";
            var adminUserName = "admin";

            var admin = await userManager.FindByEmailAsync(adminEmail)
                       ?? await userManager.FindByNameAsync(adminUserName);
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "John",
                    LastName = "Doe",
                };
                var createResult = await userManager.CreateAsync(admin, adminPassword);
                if (!createResult.Succeeded)
                {
                    var msg = string.Join("; ", createResult.Errors.Select(e => $"{e.Code}:{e.Description}"));
                    throw new Exception($"Failed to create seed admin '{adminEmail}': {msg}");
                }
            }
        }
    }
}
