using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json.Serialization;

namespace HyperSpeed.Desktop.DTOs
{
    public class CategoriaResponseDtos
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; } = string.Empty;
    }

    public class CreateCategoriaDto
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateCategoriaDto
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; } = string.Empty;
    }
}
