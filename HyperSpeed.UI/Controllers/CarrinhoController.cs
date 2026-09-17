using hyperSpeed.Application.DTOs;
using hyperSpeed.Application.Services;
using hyperSpeed.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Security.Claims;

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

        [HttpPost]
        public async Task<IActionResult> FinalizarPedido()
        {
            var itens = _carrinhoService.GetItens();

            if (itens == null || !itens.Any())
            {
                TempData["Erro"] = "Seu carrinho está vazio.";
                return RedirectToAction("Index");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                TempData["Erro"] = "Você precisa estar logado para finalizar o pedido.";
                return RedirectToAction("Login", "Conta");
            }

            var dto = new CreatePedidoDto
            {
                Itens = itens.Select(item => new CreateItemPedidoDto
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade
                }).ToList(),

                UserId = userId
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

            _carrinhoService.LimparCarrinho();

            return RedirectToAction("PedidoFinalizado");
        }
        public IActionResult PedidoFinalizado()
        {
            return View();
        }
    }
}