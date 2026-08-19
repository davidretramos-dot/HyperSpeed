<<<<<<< HEAD
﻿using hyperSpeed.Application.DTOs;

namespace HyperSpeed.UI.Models
{
    internal class ProdutoListViewModel
    {
        public IEnumerable<CategoriasDTo> Categorias { get; set; }
        public int? SelectedIdCategoria { get; set; }
    }
=======
﻿using HyperSpeed.Domain.Entities;
using SeuProjeto.ViewModels;
using System.Collections.Generic;

namespace SeuProjeto.ViewModels
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
>>>>>>> 77b9e2b5d73459be3d72769acc8838d9d0b54edb
}