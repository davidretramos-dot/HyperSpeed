using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HyperSpeed.Desktop.DTOs
{
    public class ProdutosDtos
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nomeProduto")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("descricao")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("preco")]
        public decimal Price { get; set; }

        [JsonPropertyName("imagemUrl")]
        public string CoverImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("idCategoria")]
        public int CategoryId { get; set; }

        [JsonPropertyName("nomeCategoria")]
        public string CategoryName { get; set; } = string.Empty;

        [JsonPropertyName("destaque")]
        public bool IsFeatured { get; set; }

        [JsonPropertyName("criacaoAt")]
        public DateTime CreatedAt { get; set; }
    }

    public class CreateProdutoDto
    {
        [JsonPropertyName("nomeProduto")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("descricao")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("preco")]
        public decimal Price { get; set; }

        [JsonPropertyName("imagemUrl")]
        public string CoverImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("idCategoria")]
        public int CategoryId { get; set; }

        [JsonPropertyName("destaque")]
        public bool IsFeatured { get; set; }

        [JsonPropertyName("estoque")]
        public int Stock { get; set; }
    }

    public class UpdateProdutoDto
    {
        [JsonPropertyName("nomeProduto")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("descricao")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("preco")]
        public decimal Price { get; set; }

        [JsonPropertyName("imagemUrl")]
        public string CoverImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("idCategoria")]
        public int CategoryId { get; set; }

        [JsonPropertyName("destaque")]
        public bool IsFeatured { get; set; }

        [JsonPropertyName("estoque")]
        public int Stock { get; set; }
    }
}
