using hyperSpeed.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.Services
{
    public class CarrinhoService
    {
        private readonly List<CarrinhoItem> _itens = new();

        public List<CarrinhoItem> GetItens()
        {
            return _itens;
        }

        public void AdicionarItem(CarrinhoItem item)
        {
            var itemExistente = _itens
                .FirstOrDefault(i => i.ProdutoId == item.ProdutoId);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += item.Quantidade;
            }
            else
            {
                _itens.Add(item);
            }
        }

        public void RemoverItem(int produtoId)
        {
            var item = _itens
                .FirstOrDefault(i => i.ProdutoId == produtoId);

            if (item != null)
            {
                _itens.Remove(item);
            }
        }

        public void AlterarQuantidade(int produtoId, int quantidade)
        {
            var item = _itens
                .FirstOrDefault(i => i.ProdutoId == produtoId);

            if (item != null)
            {
                item.Quantidade = quantidade;
            }
        }

        public decimal GetTotal()
        {
            return _itens.Sum(i => i.SubTotal);
        }

        public void LimparCarrinho()
        {
            _itens.Clear();
        }
    }
}
