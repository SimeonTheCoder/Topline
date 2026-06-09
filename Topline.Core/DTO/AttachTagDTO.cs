using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Topline.Core.DTO
{
    public class AttachTagDTO
    {
        [Required(ErrorMessage = "Item id is required!")]
        public string ItemId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tag id is required!")]
        public string TagId { get; set; } = string.Empty;
    }
}
