using System.Text.Json.Serialization;

namespace Topline.Infrastructure.Data.DTO
{
    public class TaggedItemDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("itemId")]
        public string ItemId { get; set; } = string.Empty;

        [JsonPropertyName("tagId")]
        public string TagId { get; set; } = string.Empty;
    }
}
