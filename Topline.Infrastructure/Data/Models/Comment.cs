using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Topline.Infrastructure.Data.Constants.EntityConstants.Item;

namespace Topline.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(ContentLengthLimit)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public User? User {get; set;} = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        public Item? Item { get; set; } = null!;
        [ForeignKey(nameof(Item))]
        public string ItemId { get; set; } = string.Empty;

        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.Now;
        }
    }
}
