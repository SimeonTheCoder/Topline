using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Topline.Infrastructure.Data.Configurations;
using Topline.Infrastructure.Data.Models;

namespace Topline.API.Extensions
{
    public static class ServicesExtensions
    {
        public static async Task<WebApplication> SeedUsersAsync(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                List<User> users = UserSeeder.SeedUsers();

                foreach (User user in users)
                {
                    IdentityResult result = await userManager.CreateAsync(user);

                    if (!result.Succeeded)
                        Console.WriteLine(string.Join("; ", result.Errors.Select(e => e.Description).ToList()));
                }
            }

            return app;
        }
    }
}
