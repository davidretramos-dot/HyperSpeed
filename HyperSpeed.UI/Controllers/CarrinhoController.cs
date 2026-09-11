using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Services;
using hyperSpeed.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HyperSpeed.UI.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoService _carrinhoService;
        private readonly IHttpClientFactory _httpClientFactory;

        public CarrinhoController(
            CarrinhoService carrinhoService,
            IHttpClientFactory httpClientFactory)
        {
            _carrinhoService = carrinhoService;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoService.GetItens();

            ViewBag.Total = _carrinhoService.GetTotal();

            return View(itens);
        }

        [HttpPost]
        public IActionResult Adicionar(
            int produtoId,
            string nome,
            decimal preco)
        {
            var item = new CarrinhoItem
            {
                ProdutoId = produtoId,
                Nome = nome,
                Preco = preco,
                Quantidade = 1
            };

            _carrinhoService.AdicionarItem(item);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int produtoId)
        {
            _carrinhoService.RemoverItem(produtoId);

            return RedirectToAction("Index");
        }

        // ==========================================
        // FINALIZAR PEDIDO
        // ==========================================

        [HttpPost]
        public async Task<IActionResult> FinalizarPedido()
        {
            var itens = _carrinhoService.GetItens();

            if (itens == null || !itens.Any())
            {
                TempData["Erro"] = "Seu carrinho está vazio.";
                return RedirectToAction("Index");
            }

            var dto = new CreatePedidoDto
            {
                Itens = itens.Select(item => new CreateItemPedidoDto
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade
                }).ToList()
            };

            var client = _httpClientFactory
                .CreateClient("HyperSpeedAPI");

            var response = await client.PostAsJsonAsync(
                "api/Pedido/Criar",
                dto
            );

            if (!response.IsSuccessStatusCode)
            {
                TempData["Erro"] =
                    "Não foi possível finalizar o pedido.";

                return RedirectToAction("Index");
            }

            // Pedido criado com sucesso
            _carrinhoService.LimparCarrinho();

            return RedirectToAction("PedidoFinalizado");
        }

        public IActionResult PedidoFinalizado()
        {
            return View();
        }
    }
}