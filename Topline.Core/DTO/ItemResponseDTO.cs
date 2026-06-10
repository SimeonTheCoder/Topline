namespace Topline.Core.DTO
{
    public class ItemResponseDTO
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Year { get; set; }

        public string Type { get; set; } = string.Empty;

        public List<TagResponseDTO> Tags { get; set; } = new();

        public List<RatingResponseDTO> Ratings { get; set; } = new();
    }
}
