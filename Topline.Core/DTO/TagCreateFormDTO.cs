using System.ComponentModel.DataAnnotations;

namespace Topline.Core.DTO
{
    public class TagCreateFormDTO
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; } = string.Empty;
    }
}
