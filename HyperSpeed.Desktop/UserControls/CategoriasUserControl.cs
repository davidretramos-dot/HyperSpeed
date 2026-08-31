using HyperSpeed.Desktop.DTOs;
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
    public partial class CategoriasUserControl : UserControl
    {

        private CategoriasApiService _categoriasService = null;
        private List<CategoriaResponseDtos> _categorias = new();

        private int? _editandoId = null;
        public CategoriasUserControl()
        {
            InitializeComponent();
        }

        private async void CategoriasUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            _categoriasService = new CategoriasApiService();
            await CarregarDadosAsync();
        }

        private async Task CarregarDadosAsync()
        {
            gridCategorias.Rows.Clear();
            try
            {
                _categorias = await _categoriasService.GetAllAsync();
                foreach (var categoria in _categorias)
                    gridCategorias.Rows.Add(categoria.Id, categoria.Name);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFormulario(CategoriaResponseDtos? categoria)
        {
            _editandoId = categoria?.Id;
            txtNome.Text = categoria?.Name ?? string.Empty;
            lblFormTitulo.Text = categoria == null ? "Nova Categoria" : $"Editando Categoria:";
            pnlForm.Visible = true;
            txtNome.Focus();
        }

        private void OcultarFormulario()
        {
            pnlForm.Visible = false;
            _editandoId = null;
            txtNome.Clear();
        }

        private void btnNova_Click(object sender, EventArgs e) => MostrarFormulario(null);

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var cat = ObterCategoriaSelecionada();
            if (cat == null)
            {
                MessageBox.Show("Selecione uma categoria para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MostrarFormulario(cat);
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var cat = ObterCategoriaSelecionada();
            if (cat == null)
            {
                MessageBox.Show("Selecione uma categoria para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cat.GameCount > 0)
            {
                MessageBox.Show(
                    $"A categoria \"{cat.Name}\" possui {cat.GameCount} game(s) vinculado(s).\nRemova os games antes de excluir.",
                    "Não é possível excluir",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conf = MessageBox.Show(
                $"Excluir a categoria \"{cat.Name}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) return;

            var (success, error) = await _categoriasService.DeleteAsync(cat.Id);
            if (success)
            {
                MessageBox.Show("✅ Categoria excluída!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome da categoria.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success;
            string error;

            if (_editandoId == null)
            {
                var dto = new CreateCategoriaDto { Name = txtNome.Text.Trim() };
                var result = await _categoriasService.CreateAsync(dto);
                success = result.success;
                error = result.ErrorMessage;
            }
            else
            {
                var dto = new UpdateCategoriaDto { Name = txtNome.Text.Trim() };
                var result = await _categoriasService.UpdateAsync(_editandoId.Value, dto);
                success = result.success;
                error = result.ErrorMessage;
            }

            if (success)
            {
                MessageBox.Show("✅ Salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OcultarFormulario();
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)=> OcultarFormulario();

        private CategoriaResponseDtos? ObterCategoriaSelecionada()
        {
            if (gridCategorias.SelectedRows.Count == 0) return null;
            var id = Convert.ToInt32(gridCategorias.SelectedRows[0].Cells["colId"].Value);
            return _categorias.FirstOrDefault(c => c.Id == id);
        }


    }
}
