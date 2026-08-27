using HyperSpeed.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HyperSpeed.Desktop.Forms
{
    public partial class ProdutoFormDialog : Form
    {
        public CreateProdutoDto? ProdutoDto { get; private set; }

        /// <summary>DTO preenchido quando no modo de edição (OK)</summary>
        public UpdateProdutoDto? UpdateDto { get; private set; }
        private List<CategoriaResponseDtos> _categorias = new();
        private ProdutosDtos? _gameExistente;
        public ProdutoFormDialog()
        {
            InitializeComponent();
        }
        public ProdutoFormDialog(List<CategoriaResponseDtos> categorias, ProdutosDtos? game)
        {
            _categorias = categorias;
            _gameExistente = game;
            InitializeComponent();
        }



        // =====================================================================
        // EVENTO LOAD
        // =====================================================================

        private void GameFormDialog_Load(object sender, EventArgs e)
        {
            //Guard
            if (DesignMode) return;

            // Configura título baseado no modo (criação/edição)
            this.Text = _gameExistente == null ? "Novo Game" : "Editar Game";
            lblTituloForm.Text = _gameExistente == null ? "➕ Novo Game" : "✏️ Editar Game";

            //Popula o ComboBox de categorias
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Selecione uma categoria...");
            foreach (var cat in _categorias)
                cmbCategoria.Items.Add(cat.Name);
            cmbCategoria.SelectedIndex = 0;

            //Preenche campos se estiver no modo edição
            PreencherCampos();

        }

        // =====================================================================
        // PREENCHIMENTO (MODO EDIÇÃO)
        // =====================================================================

        private void PreencherCampos()
        {
            if (_gameExistente == null) return;

            txtTitulo.Text = _gameExistente.Title;
            txtDescricao.Text = _gameExistente.Description;
            txtPreco.Text = _gameExistente.Price.ToString("F2");
            txtCoverUrl.Text = _gameExistente.CoverImageUrl;
            chkDestaque.Checked = _gameExistente.IsFeatured;

            var idx = _categorias.FindIndex(c => c.Id == _gameExistente.CategoryId);
            if (idx >= 0) cmbCategoria.SelectedIndex = idx + 1;

        }





        // =====================================================================
        // SALVAR
        // =====================================================================
        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show(
                    "Informe o título do game.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco < 0 || preco > decimal.MaxValue)
            {
                MessageBox.Show(
                 "Informe um Preço válido.",
                 "Validação",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategoria.SelectedIndex <= 0)
            {
                MessageBox.Show(
                 "Selecione uma categoria",
                 "Validação",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            var categoriaIdx = cmbCategoria.SelectedIndex - 1;
            var categoriaId = _categorias[categoriaIdx].Id;

            if (_gameExistente == null)
            {
                ProdutoDto = new CreateProdutoDto
                {
                    Title = txtTitulo.Text.Trim(),
                    Description = txtDescricao.Text.Trim(),
                    Price = preco,
                    CoverImageUrl = txtCoverUrl.Text.Trim(),
                    CategoryId = categoriaId,
                    IsFeatured = chkDestaque.Checked
                };
            }
            else
            {
                UpdateDto = new UpdateProdutoDto
                {
                    Title = txtTitulo.Text.Trim(),
                    Description = txtDescricao.Text.Trim(),
                    Price = preco,
                    CoverImageUrl = txtCoverUrl.Text.Trim(),
                    CategoryId = categoriaId,
                    IsFeatured = chkDestaque.Checked
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
