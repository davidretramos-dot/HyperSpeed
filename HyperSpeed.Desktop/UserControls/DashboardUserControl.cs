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
    public partial class DashboardUserControl : UserControl
    {
        private ProdutosApiService _produtosService = null;
        private CategoriasApiService _categoriasService = null;

        public DashboardUserControl()
        {
            InitializeComponent();
        }

        private async void DashboardUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            _produtosService = new ProdutosApiService();
            _categoriasService = new CategoriasApiService();
            lblTitulo.Text = $"Olá, {SessionManager.Instance.GetDisplayName()!}";
            lblSubtitulo.Text = $"Seja bem-vindo(a) ao HyperSpeed, {DateTime.Now:dd/MM/yyyy}";
            await CarregarDadosAsync();
        }

        private async Task CarregarDadosAsync()
        {
            SetCarregando(true);
            try
            {
                var tarefaProdutos = _produtosService.GetAllAsync();
                var tarefaCategorias = _categoriasService.GetAllAsync();
                await Task.WhenAll(tarefaProdutos, tarefaCategorias);

                var produtos = tarefaProdutos.Result;
                var categorias = tarefaCategorias.Result;

                cardGamesLblNumero.Text = produtos.Count.ToString();
                cardCategoriasLblNumero.Text = categorias.Count.ToString();

                gridUltimosGames.Rows.Clear();
                foreach(var produto in produtos.OrderByDescending(x => x.CreatedAt).Take(10))
                {
                    gridUltimosGames.Rows.Add(
                        produto.Id,
                        produto.Title,
                        produto.CategoryName,
                        produto.Price.ToString("C"),
                        produto.CreatedAt.ToString("dd/MM/yyyy")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", 
                    "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                SetCarregando(false);
            }
        }
    }
}
