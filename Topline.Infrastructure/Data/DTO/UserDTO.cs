using System.Text.Json.Serialization;

namespace Topline.Infrastructure.Data.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("passwordHash")]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
