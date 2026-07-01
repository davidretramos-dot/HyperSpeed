using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;
using HyperSpeed.Domain.Entities; // ou namespace correto

namespace SeuProjeto.Controllers
{
    public class ProdutoController : Controller
    {
        // Lista de produtos
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ProdutoListViewModel
            {
                Produtos = new List<Produto>
                {
                    new Produto
                    {
                        Id = 1,
                        Nome = "Ryzen 7 7700X",
                        Descricao = "Processador AMD Ryzen 7",
                        Preco = 1999.90m,
                        Estoque = 10,
                        IdCategoria = 1,
                        Imagem = "/images/produtos/cpu-amd.png"
                    },
                    new Produto
                    {
                        Id = 2,
                        Nome = "RTX 4070",
                        Descricao = "Placa de vídeo NVIDIA",
                        Preco = 4299.90m,
                        Estoque = 5,
                        IdCategoria = 2,
                        Imagem = "/images/produtos/gpu.png"
                    }
                }
            };

            return View(model);
        }

        // Detalhes do produto
        [HttpGet]
        public IActionResult Details(int id)
        {
            var produto = new ProdutoDetailsViewModel
            {
                Id = id,
                Nome = "Ryzen 7 7700X",
                Descricao = "Processador AMD Ryzen 7 7700X",
                Preco = 1999.90m,
                Estoque = 10,
                Categoria = "Processadores",
                ImagemUrl = "/images/produtos/cpu-amd.png"
            };

            return View(produto);
        }

        // Página de cadastro
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProdutoViewModel());
        }

        // Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Salvar no banco futuramente

            TempData["Sucesso"] = "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        // Editar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = new ProdutoViewModel
            {
                Id = id,
                Nome = "Ryzen 7 7700X",
                Descricao = "Processador AMD",
                Preco = 1999.90m,
                Estoque = 10,
                CategoriaId = 1,
                ImagemUrl = "/images/produtos/cpu-amd.png"
            };

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Atualizar no banco

            TempData["Sucesso"] = "Produto atualizado!";

            return RedirectToAction(nameof(Index));
        }

        // Excluir
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = new ProdutoViewModel
            {
                Id = id,
                Nome = "Ryzen 7 7700X"
            };

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Remover do banco

            TempData["Sucesso"] = "Produto removido!";

            return RedirectToAction(nameof(Index));
        }

        // Pesquisa
        [HttpGet]
        public IActionResult Pesquisa(string pesquisa)
        {
            var model = new ProdutoListViewModel
            {
                Pesquisa = pesquisa,
                Produtos = new List<Produto>() // antes: new List<ProdutoViewModel>()
            };

            return View("Index", model);
        }

        // Promoções
        [HttpGet]
        public IActionResult Promocoes()
        {
            return View("Index");
        }

        // Periféricos
        [HttpGet]
        public IActionResult Perifericos()
        {
            return View("Index");
        }
    }
}