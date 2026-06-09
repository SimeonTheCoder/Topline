using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Topline.Infrastructure.Data.Models
{
    public class TaggedItem
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;

        public Item? Item { get; set; } = null!;
        [ForeignKey(nameof(Item))]
        public string ItemId { get; set; } = string.Empty;

        public User? User { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        public TaggedItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
