using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HyperSpeed.UI.Services;

namespace HyperSpeed.UI.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly HttpPedidoService _pedidoApi;

        public PedidoController(HttpPedidoService pedidoApi)
        {
            _pedidoApi = pedidoApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoApi.GetMeusPedidosAsync();

            return View(pedidos);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pedido = await _pedidoApi.GetByIdAsync(id);

            if (pedido == null)
                return NotFound();

            return View("~/Views/Pedido/Details.cshtml", pedido);
        }
    }
}