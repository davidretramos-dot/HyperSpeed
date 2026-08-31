using HyperSpeed.Desktop.DTOs;
using HyperSpeed.Desktop.Forms;
using HyperSpeed.Desktop.Helpers;
using HyperSpeed.Desktop.Services;
using HyperSpeed.Desktop.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HyperSpeed.Desktop.UserControls
{
    public partial class UsuariosUserControl : UserControl
    {
        private UsuariosApiService _usuariosService = null!;
        private List<UsuarioResponseDto> _todosusuarios = new();
        private List<string> _perfis = new();

        public UsuariosUserControl()
        {
            InitializeComponent();
        }

        private async void UsuariosUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            _usuariosService = new UsuariosApiService();
            ConfigurarPermissoes();

            await CarregarDadosAsync();
        }

        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnNovo.Visible = isAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
        }

        private async Task CarregarDadosAsync()
        {
            gridUsuarios.Rows.Clear();

            try
            {
                var tarefaUsuarios = _usuariosService.GetAllAsync();
                var tarefaPerfis = _usuariosService.GetPerfisAsync();
                await Task.WhenAll(tarefaUsuarios, tarefaPerfis);

                _todosusuarios = tarefaUsuarios.Result;
                _perfis = tarefaPerfis.Result;

                PopularGrid(_todosusuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopularGrid(List<UsuarioResponseDto> usuarios)
        {
            gridUsuarios.Rows.Clear();
            foreach (var u in usuarios)
            {
                gridUsuarios.Rows.Add(
                    u.Id,
                    u.Name,
                    u.Email,
                    u.Perfil);
            }
        }



        private void FiltrarUsuarios()
        {
            var termo = txtPesquisa.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosusuarios);
                return;
            }

            var filtrados = _todosusuarios
                .Where(u => u.Name.ToLower().Contains(termo, StringComparison.OrdinalIgnoreCase)
                        || u.Email.ToLower().Contains(termo, StringComparison.OrdinalIgnoreCase))
                .ToList();
            PopularGrid(filtrados);
        }

        private async void btnNovo_Click(object sender, EventArgs e)
        {
            using var form = new UsuarioFormDialog(_perfis, null);
            if (form.ShowDialog() == DialogResult.OK && form.UsuarioDto != null)
            {
                var (success, _, error) = await _usuariosService.CreateAsync(form.UsuarioDto);
                if (success)
                {
                    MessageBox.Show("✅ Usuário criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var usuario = ObterUsuarioSelecionado();
            if (usuario == null)
            {
                MessageBox.Show("Selecione um usuário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conf = MessageBox.Show(
                $"Tem certeza que deseja excluir o usuário:\n\"{usuario.Name}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) return;

            var (success, error) = await _usuariosService.DeleteAsync(usuario.Id);
            if (success)
            {
                MessageBox.Show("✅ Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarDadosAsync();

        private UsuarioResponseDto? ObterUsuarioSelecionado()
        {
            if (gridUsuarios.SelectedRows.Count == 0) return null;
            var row = gridUsuarios.SelectedRows[0];
            var id = row.Cells["colId"].Value?.ToString();
            return _todosusuarios.FirstOrDefault(u => u.Id == id);
        }

        private void GridUsuarios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        => btnEditar_Click(sender, e);

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var usuario = ObterUsuarioSelecionado();
            if (usuario == null)
            {
                MessageBox.Show("Selecione um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new UsuarioFormDialog(_perfis, usuario);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                var (success, _, error) = await _usuariosService.UpdateAsync(usuario.Id, form.UpdateDto);
                if (success)
                {
                    MessageBox.Show("✅ Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e) => FiltrarUsuarios();
    }
}
