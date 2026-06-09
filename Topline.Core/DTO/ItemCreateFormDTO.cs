using System.ComponentModel.DataAnnotations;

using static Topline.Infrastructure.Data.Constants.EntityConstants.Item;

namespace Topline.Core.DTO
{
    public class ItemCreateFormDTO
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Artist is required!")]
        public string Artist { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required!")]
        [MaxLength(ContentLengthLimit, ErrorMessage = "Description too long!")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Item type is required!")]
        public string Type { get; set; } = string.Empty;
    }
}
