using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Topline.Infrastructure.Data.DTO
{
    public class TagDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
