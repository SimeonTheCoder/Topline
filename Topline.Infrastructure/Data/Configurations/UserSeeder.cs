using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Text.Json;
using Topline.Infrastructure.Data.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Infrastructure.Data.Configurations
{
    public class UserSeeder
    {
        const string JsonPath = "../Topline.Infrastructure/Data/JSON/users.json";

        public static List<User> SeedUsers()
        {
            string path = JsonPath;
            string startLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            string text = File.ReadAllText(path);

            List<User> seededUsers = JsonSerializer.Deserialize<List<UserDTO>>(text)!.Select(dto =>
            {
                return new User()
                {
                    Email = dto.Email,
                    UserName = dto.Email,
                    PasswordHash = dto.PasswordHash,
                };
            }).ToList();

            return seededUsers;
        }
    }
}
