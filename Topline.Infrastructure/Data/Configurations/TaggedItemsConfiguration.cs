using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Text.Json;
using Topline.Infrastructure.Data.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Infrastructure.Data.Configurations
{
    public class TaggedItemsConfiguration : IEntityTypeConfiguration<TaggedItem>
    {
        const string JsonPath = "../Topline.Infrastructure/Data/JSON/tagged-albums.json";

        public void Configure(EntityTypeBuilder<TaggedItem> builder)
        {
            string path = JsonPath;
            string startLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            string text = File.ReadAllText(path);

            List<TaggedItem> seededData = JsonSerializer.Deserialize<List<TaggedItemDTO>>(text)!.Select(dto =>
            {
                return new TaggedItem()
                {
                    Id = dto.Id,
                    ItemId = dto.ItemId,
                    TagId = dto.TagId,
                };
            }).ToList();

            builder.HasData(seededData);
        }
    }
}
