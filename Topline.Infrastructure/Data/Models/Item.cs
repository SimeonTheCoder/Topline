using System.ComponentModel.DataAnnotations;
using Topline.Infrastructure.Data.Enums;

using static Topline.Infrastructure.Data.Constants.EntityConstants.Item;

namespace Topline.Infrastructure.Data.Models
{
    public class Item
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(TitleLengthLimit, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; } = 0;

        [Required]
        public string Artist { get; set; } = string.Empty;

        [MaxLength(ContentLengthLimit)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public ItemType Type { get; set; } = ItemType.Song;

        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
