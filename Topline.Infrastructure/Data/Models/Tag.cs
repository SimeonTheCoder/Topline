using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Topline.Infrastructure.Data.Models
{
    public class Tag
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public Tag()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
