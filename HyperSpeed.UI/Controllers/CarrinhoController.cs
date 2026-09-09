using hyperSpeed.Application.Services;
using hyperSpeed.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class CarrinhoController : Controller
{
    private readonly CarrinhoService _carrinhoService;

    public CarrinhoController(CarrinhoService carrinhoService)
    {
        _carrinhoService = carrinhoService;
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
}