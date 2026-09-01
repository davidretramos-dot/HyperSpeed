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
    public partial class PerfilUserControl : UserControl
    {
        private AuthApiService _authService = null!;
        public PerfilUserControl()
        {
            InitializeComponent();
        }

        private void PerfilUserControl_Load(object sender, EventArgs e)
        {
            _authService = new AuthApiService();

            var displayName = SessionManager.Instance.GetDisplayName();
            var email = SessionManager.Instance.GetEmail();
            var isAdmin = SessionManager.Instance.IsAdmin;

            lblAvatar.Text = displayName.Length > 0 ? displayName.Substring(0, 1).ToUpper() : "U";

            lblNome.Text = displayName;
            lblEmailValor.Text = email;
            lblApiValor.Text = AppConfig.ApiBaseUrl;

            var perfil = isAdmin ? "Administrador" : "Usuário";
            lblBadge.Text = perfil;

            var roles = SessionManager.Instance.CurrentUser?.Regras ?? new List<string>();

            lblRolesValor.Text = roles.Count > 0 ? string.Join(", ", roles) : "Sem perfil atribuído";
        }
    }
}