using System.Text.Json;
using hyperSpeed.Application.ViewModels;
using Microsoft.AspNetCore.Http;

namespace hyperSpeed.Application.Services
{
    public class CarrinhoService
    {
        private const string SessionKey = "Carrinho";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarrinhoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session =>
            _httpContextAccessor.HttpContext!.Session;

        public List<CarrinhoItem> GetItens()
        {
            var json = Session.GetString(SessionKey);

            if (string.IsNullOrEmpty(json))
                return new List<CarrinhoItem>();

            return JsonSerializer.Deserialize<List<CarrinhoItem>>(json)
                   ?? new List<CarrinhoItem>();
        }

        private void SalvarItens(List<CarrinhoItem> itens)
        {
            var json = JsonSerializer.Serialize(itens);
            Session.SetString(SessionKey, json);
        }

        public void AdicionarItem(CarrinhoItem item)
        {
            var itens = GetItens();

            var itemExistente = itens.FirstOrDefault(
                i => i.ProdutoId == item.ProdutoId);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += item.Quantidade;
            }
            else
            {
                itens.Add(item);
            }

            SalvarItens(itens);
        }

        public void RemoverItem(int produtoId)
        {
            var itens = GetItens();

            var item = itens.FirstOrDefault(
                i => i.ProdutoId == produtoId);

            if (item != null)
            {
                itens.Remove(item);
                SalvarItens(itens);
            }
        }

        public void AlterarQuantidade(int produtoId, int quantidade)
        {
            var itens = GetItens();

            var item = itens.FirstOrDefault(
                i => i.ProdutoId == produtoId);

            if (item != null)
            {
                item.Quantidade = quantidade;
                SalvarItens(itens);
            }
        }

        public decimal GetTotal()
        {
            return GetItens().Sum(i => i.SubTotal);
        }

        public void LimparCarrinho()
        {
            Session.Remove(SessionKey);
        }
    }
}