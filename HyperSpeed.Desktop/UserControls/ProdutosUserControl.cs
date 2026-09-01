using HyperSpeed.Desktop.DTOs;
using HyperSpeed.Desktop.Forms;
using HyperSpeed.Desktop.Helpers;
using HyperSpeed.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HyperSpeed.Desktop.UserControls
{
    public partial class ProdutosUserControl : UserControl
    {
        private ProdutosApiService _produtoService = null;
        private CategoriasApiService _categoriasService = null;

        private List<ProdutosDtos> _todosProdutos = new();
        private List<CategoriaResponseDtos> _categorias = new();


        public ProdutosUserControl()
        {
            InitializeComponent();
        }

        private async void GamesUserControl_Load(object sender, EventArgs e)
        {
            _produtoService = new ProdutosApiService();
            _categoriasService = new CategoriasApiService();
            ConfigurarPermissoes();
            await CarregarDadosAsync();
        }

        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnNova.Visible = isAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
        }

        private async Task CarregarDadosAsync()
        {
            gridProdutos.Rows.Clear();
            try
            {
                var tarefaProdutos = _produtoService.GetAllAsync();
                var tarefaCategorias = _categoriasService.GetAllAsync();
                await Task.WhenAll(tarefaProdutos, tarefaCategorias);

                _todosProdutos = tarefaProdutos.Result;
                _categorias = tarefaCategorias.Result;
                PopularGrid(_todosProdutos);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carragar games: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void PopularGrid(List<ProdutosDtos> produtos)
        {
            gridProdutos.Rows.Clear();
            foreach (var g in produtos)
            {
                gridProdutos.Rows.Add(
                    g.Id,
                    g.Title,
                    g.CategoryName,
                    g.Price,
                    g.IsFeatured,
                    g.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e) => FiltrarProdutos();

        private void FiltrarProdutos()
        {
            var termo = txtPesquisa.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosProdutos);
                return;
            }

            var filtrados = _todosProdutos
                .Where(g => g.Title.Contains(termo, StringComparison.OrdinalIgnoreCase)
                || g.CategoryName.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .ToList();
            PopularGrid(filtrados);
        }

        private void btnPesquisar_KeyUp(object sender, KeyEventArgs e) => FiltrarProdutos();

        private async void btnNova_Click(object sender, EventArgs e)
        {
            using var form = new ProdutoFormDialog(_categorias, null);
            if (form.ShowDialog() == DialogResult.OK && form.ProdutoDto != null)
            {
                var (success, _, error) = await _produtoService.CreateAsync(form.ProdutoDto);
                if (success)
                {
                    MessageBox.Show("✅ Produto criado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}",
                      "Erro",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var produtos = ObterProdutosSelecionado();
            if (produtos == null)
            {
                MessageBox.Show($"Selecione um produto para editar.",
                      "Aviso",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                return;
            }
            using var form = new ProdutoFormDialog(_categorias, produtos);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                var (success, _, error) = await _produtoService.UpdateAsync(produtos.Id, form.UpdateDto);
                if (success)
                {
                    MessageBox.Show("✅ Produto atualizado com sucesso  ",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}",
                      "Erro",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
            }
        }

        private ProdutosDtos ObterProdutosSelecionado()
        {
            if (gridProdutos.SelectedRows.Count == 0)
                return null;
            var row = gridProdutos.SelectedRows[0];
            var id = Convert.ToInt32(row.Cells["colId"].Value);
            return _todosProdutos.FirstOrDefault(p => p.Id == id);
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var game = ObterProdutosSelecionado();
            if (game == null)
            {
                MessageBox.Show("Selecione um produto para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conf = MessageBox.Show(
                $"Tem certeza que deseja excluir o produto:\n\"{game.Title}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) return;

            var (success, error) = await _produtoService.DeleteAsync(game.Id);
            if (success)
            {
                MessageBox.Show("✅ Produto excluído com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();
    }
}
