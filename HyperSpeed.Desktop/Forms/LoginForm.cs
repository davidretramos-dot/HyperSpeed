using HyperSpeed.Desktop.Helpers;
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
    public partial class LoginForm : Form
    {
        private AuthApiService _authService = null!;
        public LoginForm()
        {
            InitializeComponent();
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Guard: não executa em tempo de design
            if (DesignMode) return;

            _authService = new AuthApiService();

            lblVersao.Text = $"Versão {AppConfig.Version} | ©️ {DateTime.Now.Year} HS Desk do top";
            lblApi.Text = $"API: {AppConfig.ApiBaseUrl}";

            txtEmail.Text = "adminHS@gmail.com";
            txtSenha.Text = "Admin@123";
        }
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtSenha.Focus();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
           
        }

        private void ExibirErro(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
            {
                lblErro.Visible = false;
                lblErro.Text = string.Empty;
            }
            else
            {
                lblErro.Text = mensagem;
                lblErro.Visible = true;
            }
        }

        private void SetCarregando(bool carregando)
        {
            btnEntrar.Enabled = !carregando;
            txtEmail.Enabled = !carregando;
            txtSenha.Enabled = !carregando;
            lblCarregando.Visible = carregando;

            if (carregando)
            {
                btnEntrar.Text = "Aguarde...";
                lblErro.Visible = false;
            }
            else
            {
                btnEntrar.Text = "Entrar";
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEntrar_Click_1(sender, e);
        }

        private async void btnEntrar_Click_1(object sender, EventArgs e)
        {
            ExibirErro(string.Empty);

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ExibirErro("⚠️ Informe seu e-mail!");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                ExibirErro("⚠️ Informe sua senha!");
                txtSenha.Focus();
                return;
            }

            SetCarregando(true);

            try
            {
                var email = txtEmail.Text.Trim();
                var senha = txtSenha.Text.Trim();

                // 🔍 DEBUG: Log dos dados sendo enviados
                System.Diagnostics.Debug.WriteLine($"[LOGIN DEBUG] Email: '{email}' (length: {email.Length})");
                System.Diagnostics.Debug.WriteLine($"[LOGIN DEBUG] Senha: '{senha}' (length: {senha.Length})");
                System.Diagnostics.Debug.WriteLine($"[LOGIN DEBUG] API Base URL: {AppConfig.ApiBaseUrl}");

                var (success, user, errorMessage) = await _authService.LoginAsync(email, senha);

                if (success && user != null)
                {
                    SessionManager.Instance.SetUser(user);
                    this.Hide();
                    using var mainform = new MainForm();
                    mainform.ShowDialog();
                    this.Close();
                }
                else
                {
                    ExibirErro($"❌ {errorMessage}");
                    System.Diagnostics.Debug.WriteLine($"[LOGIN DEBUG] Erro: {errorMessage}");
                    MessageBox.Show($"❌ {errorMessage}");
                }
            }
            catch (HttpRequestException exHttp)
            {
                ExibirErro($"❌ Não foi possível conectar à API. \nVerifique se a API está em execução erro do sistema: {exHttp.Message}");
                MessageBox.Show($"❌ Não foi possível conectar à API. \nVerifique se a API está em execução erro do sistema: {exHttp.Message}");
            }
            catch (Exception ex)
            {
                ExibirErro($"❌ Erro inesperado: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[LOGIN DEBUG] Erro inesperado: {ex}");
                MessageBox.Show($"❌ Erro inesperado: {ex.Message}");
            }
            finally
            {
                SetCarregando(false);
            }
        }
    }
}
