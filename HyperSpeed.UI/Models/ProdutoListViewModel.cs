using HyperSpeed.Domain.Entities;
using SeuProjeto.ViewModels;
using System.Collections.Generic;
using hyperSpeed.Application.DTOs;

namespace HyperSpeed.UI.Models

    {
        public class ProdutoListViewModel
        {
            public IEnumerable<Produto> Produtos { get; set; } = new List<Produto>();

            public string? Pesquisa { get; set; }

            public int? CategoriaId { get; set; }

            public string? CategoriaNome { get; set; }

            public int PaginaAtual { get; set; } = 1;

            public int TotalPaginas { get; set; } = 1;
        }

    }
