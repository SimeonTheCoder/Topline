using System.ComponentModel.DataAnnotations;

namespace Topline.Core.DTO
{
    public class RatingCreateFormDTO
    {
        [Required(ErrorMessage = "Score is required!")]
        public int Score { get; set; } = 0;

        [Required(ErrorMessage = "Date is required!")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "User is required!")]
        public string UserId = string.Empty;

        [Required(ErrorMessage = "Item is required!")]
        public string ItemId = string.Empty;
    }
}
