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
    public partial class UsuarioFormDialog : Form
    {
        public CreateUsuarioDto? UsuarioDto { get; private set; }
        public UpdateUsuarioDto? UpdateDto { get; private set; }

        private List<string> _perfis = new();
        private UsuarioResponseDto? _usuarioExistente;
        public UsuarioFormDialog()
        {
            InitializeComponent();
        }

        public UsuarioFormDialog(List<string> perfis, UsuarioResponseDto? usuarioExistente = null)
            : this()
        {
            _perfis = perfis;
            _usuarioExistente = usuarioExistente;

            PreencherComboPerfis();

            if (_usuarioExistente != null)
            {
                lblTituloForm.Text = "✏️ Editar Usuário";
                txtNome.Text = _usuarioExistente.Name;
                txtEmail.Text = _usuarioExistente.Email;

                if (cmbPerfil.Items.Contains(_usuarioExistente.Perfil))
                {
                    cmbPerfil.SelectedItem = _usuarioExistente.Perfil;
                }
            }
            else
            {
                lblTituloForm.Text += "Novo Usuário";
                if (cmbPerfil.Items.Count > 0)
                    cmbPerfil.SelectedIndex = 0;
            }
        }

        private void PreencherComboPerfis()
        {
            cmbPerfil.Items.Clear();
            foreach (var perfil in _perfis)
            {
                cmbPerfil.Items.Add(perfil);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Nome e Email são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_usuarioExistente == null && string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Senha é obrigatória para novos usuários.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As senhas não coincidem.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPerfil.SelectedItem == null)
            {
                MessageBox.Show("Selecione um perfil.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_usuarioExistente == null)
            {
                UsuarioDto = new CreateUsuarioDto
                {
                    Nome = txtNome.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Senha = txtSenha.Text,
                    ConfirmarSenha = txtConfirmarSenha.Text,
                    Perfil = cmbPerfil.SelectedItem.ToString()!
                };
            }
            else
            {
                UpdateDto = new UpdateUsuarioDto
                {
                    Nome = txtNome.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Senha = string.IsNullOrEmpty(txtSenha.Text) ? null : txtSenha.Text,
                    ConfirmarSenha = string.IsNullOrEmpty(txtConfirmarSenha.Text) ? null : txtConfirmarSenha.Text,
                    Perfil = cmbPerfil.SelectedItem.ToString()!
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
