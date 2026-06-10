using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Topline.Core.DTO
{
    public class RatingResponseDTO
    {
        public string Id { get; set; } = string.Empty;

        public int Score { get; set; } = 0;

        public DateTime Date { get; set; }

        public string UserId = string.Empty;

        public string ItemId = string.Empty;
    }
}
