using Microsoft.AspNetCore.Identity;
using PaaPinden.Data;

namespace PaaPinden.Data;

public static class AdminAccountSeeder
{
    private const string AdminRole = "admin";

    public static async Task SeedAsync(IServiceProvider services, IConfiguration configuration)
    {
        var email = configuration["AdminSeed:Email"];
        var password = configuration["AdminSeed:Password"];

        if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException("Both AdminSeed:Email and AdminSeed:Password must be configured.");
        }

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(AdminRole))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(AdminRole));
            EnsureSucceeded(roleResult, "creating the admin role");
        }

        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var userResult = await userManager.CreateAsync(user, password);
            EnsureSucceeded(userResult, "creating the admin account");
        }

        if (!await userManager.IsInRoleAsync(user, AdminRole))
        {
            var roleResult = await userManager.AddToRoleAsync(user, AdminRole);
            EnsureSucceeded(roleResult, "assigning the admin role");
        }
    }

    private static void EnsureSucceeded(IdentityResult result, string operation)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(error => error.Description));
            throw new InvalidOperationException($"Failed {operation}: {errors}");
        }
    }
}
