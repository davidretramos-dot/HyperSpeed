using HyperSpeed.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HyperSpeed.Desktop.Forms
{
    public partial class RedefinirSenhaForm : Form
    {
        private readonly RecuperacaoSenhaApiService _recuperacaoService;
        private readonly string _email;
        private readonly string _token;

        public RedefinirSenhaForm(string email, string token)
        {
            InitializeComponent();
            _recuperacaoService = new RecuperacaoSenhaApiService();
            _email = email; _token = token;
            
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtNovaSenha.Text)) { MessageBox.Show("Informe a nova senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtNovaSenha.Focus(); return; }
                if (string.IsNullOrWhiteSpace(txtConfirNova.Text)) { MessageBox.Show("Confirme a nova senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtConfirNova.Focus(); return; }
                if (txtNovaSenha.Text != txtConfirNova.Text) { MessageBox.Show("As senhas não coincidem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtConfirNova.Focus(); return; }
                btnConfirmar.Enabled = false; btnConfirmar.Text = "Aguarde..."; try { await _recuperacaoService.RedefinirSenhaAsync(_email, _token, txtNovaSenha.Text, txtConfirNova.Text); MessageBox.Show("Senha redefinida com sucesso!\n\n" + "Agora você pode fazer login utilizando sua nova senha.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); this.DialogResult = DialogResult.OK; this.Close(); } catch (Exception ex) { MessageBox.Show($"Não foi possível redefinir a senha.\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); } finally { btnConfirmar.Enabled = true; btnConfirmar.Text = "Confirmar"; }
            }
        }
    }
}
