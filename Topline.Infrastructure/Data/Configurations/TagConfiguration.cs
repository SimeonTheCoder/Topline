using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Text.Json;
using Topline.Infrastructure.Data.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.Infrastructure.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        const string JsonPath = "../Topline.Infrastructure/Data/JSON/tags.json";

        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            string path = JsonPath;
            string startLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            string text = File.ReadAllText(path);

            List<Tag> seededTags = JsonSerializer.Deserialize<List<TagDTO>>(text)!.Select(dto =>
            {
                return new Tag()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                };
            }).ToList();

            builder.HasData(seededTags);
        }
    }
}
