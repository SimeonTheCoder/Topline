using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Text.Json;
using Topline.Infrastructure.Data.DTO;
using Topline.Infrastructure.Data.Enums;
using Topline.Infrastructure.Data.Models;

namespace Topline.Infrastructure.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        const string JsonPath = "../Topline.Infrastructure/Data/JSON/items.json";

        public void Configure(EntityTypeBuilder<Item> builder)
        {
            string path = JsonPath;
            string startLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            string text = File.ReadAllText(path);

            List<Item> seededItems = JsonSerializer.Deserialize<List<ItemDTO>>(text)!.Select(dto =>
            {
                ItemType currItemType;
                Enum.TryParse(dto.Type, out currItemType);

                return new Item()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Artist = dto.Artist,
                    Year = dto.Year,
                    Description = dto.Description,
                    Type = currItemType
                };
            }).ToList();

            builder.HasData(seededItems);
        }
    }
}
