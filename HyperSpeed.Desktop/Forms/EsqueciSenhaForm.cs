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
    public partial class EsqueciSenhaForm : Form
    {
        private readonly RecuperacaoSenhaApiService _recuperacaoService;



        public EsqueciSenhaForm()
        {
            InitializeComponent();
            _recuperacaoService = new RecuperacaoSenhaApiService(); 
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Informe seu e-mail.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus(); return;
                }
                btnConfirmar.Enabled = false; btnConfirmar.Text = "Aguarde..."; try { string email = txtEmail.Text.Trim(); string token = await _recuperacaoService.SolicitarTokenAsync(email); MessageBox.Show("Token de recuperação gerado com sucesso!\n\n" + "Como esta é a versão acadêmica do sistema, " + "o token será exibido agora.", "Recuperação de senha", MessageBoxButtons.OK, MessageBoxIcon.Information); using var redefinirSenhaForm = new RedefinirSenhaForm(email, token); this.Hide(); var resultado = redefinirSenhaForm.ShowDialog(); this.Show(); if (resultado == DialogResult.OK) { this.Close(); } } catch (Exception ex) { MessageBox.Show($"Não foi possível iniciar a recuperação de senha.\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); } finally { btnConfirmar.Enabled = true; btnConfirmar.Text = "Confirmar"; }
            }
        }
    }
}
