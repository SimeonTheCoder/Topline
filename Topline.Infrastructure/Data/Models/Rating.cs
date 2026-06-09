using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Topline.Infrastructure.Data.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public int Score { get; set; } = 0;

        [Required]
        public DateTime Date { get; set; }

        public User? User { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId = string.Empty;

        public Item? Item { get; set; } = null!;
        [ForeignKey(nameof(Item))]
        public string ItemId = string.Empty;

        public Rating()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.Now;
        }
    }
}
