using hyperSpeed.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace hyperSpeed.Application.ViewModels
{
    public class HomeViewModels
    {
        public IEnumerable<ProdutoDTo> ProdutosDestaque {  get; set; } = new List<ProdutoDTo>();
        public IEnumerable<CategoriasDTo> Categorias {  get; set; } = new List<CategoriasDTo>();
        public IEnumerable<ProdutoDTo> ProdutosRecentes { get; set; } = new List<ProdutoDTo>();
    }

    public class DetalhesProdutoViewModels
    {
        public ProdutoDTo Produto { get; set; } = new ProdutoDTo();
        public IEnumerable<ProdutoDTo> Lansamentoprodutos { get; set; } = Enumerable.Empty<ProdutoDTo>();
    }




    internal class ListaProdutoViewModels
    {
        public IEnumerable<ProdutoDTo> Produtos { get; set; } = new List<ProdutoDTo>();
        public IEnumerable<CategoriasDTo> Categorias { get; set; } = new List<CategoriasDTo>();
        public int? SelecionaCadegoriasId { get; set; }
    }
}
