namespace HyperSpeed.Desktop.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            lblLoginForm = new Label();
            lblSenha = new Label();
            lblEmail = new Label();
            btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            pnSeparador = new Panel();
            pnlSeparador2 = new Panel();
            lblCarregando = new Label();
            lblProblemas = new Label();
            lblApi = new Label();
            lblVersao = new Label();
            lblErro = new Label();
            lblTextoFacaLogin = new Label();
            pbLogo = new PictureBox();
            btnFechar = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 10;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.Black;
            txtEmail.BorderRadius = 7;
            txtEmail.CustomizableEdges = customizableEdges6;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FillColor = Color.FromArgb(16, 16, 16);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.ForeColor = Color.FromArgb(224, 224, 224);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(12, 140);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.PlaceholderText = "seuemail@email.com";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtEmail.Size = new Size(439, 38);
            txtEmail.TabIndex = 0;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // txtSenha
            // 
            txtSenha.BorderColor = Color.Black;
            txtSenha.BorderRadius = 7;
            txtSenha.CustomizableEdges = customizableEdges4;
            txtSenha.DefaultText = "";
            txtSenha.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSenha.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSenha.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.FillColor = Color.FromArgb(16, 16, 16);
            txtSenha.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Font = new Font("Segoe UI", 9F);
            txtSenha.ForeColor = Color.FromArgb(224, 224, 224);
            txtSenha.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Location = new Point(12, 224);
            txtSenha.Name = "txtSenha";
            txtSenha.PlaceholderForeColor = Color.FromArgb(64, 64, 64);
            txtSenha.PlaceholderText = "•••••••";
            txtSenha.SelectedText = "";
            txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtSenha.Size = new Size(439, 38);
            txtSenha.TabIndex = 1;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // lblLoginForm
            // 
            lblLoginForm.AutoSize = true;
            lblLoginForm.Font = new Font("Yu Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginForm.ForeColor = Color.FromArgb(166, 2, 73);
            lblLoginForm.Location = new Point(186, 34);
            lblLoginForm.Name = "lblLoginForm";
            lblLoginForm.Size = new Size(172, 35);
            lblLoginForm.TabIndex = 5;
            lblLoginForm.Text = "Bem-Vindo!";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSenha.ForeColor = Color.White;
            lblSenha.Location = new Point(27, 204);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(64, 17);
            lblSenha.TabIndex = 7;
            lblSenha.Text = "Senha  *";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(28, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 17);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email *";
            // 
            // btnEntrar
            // 
            btnEntrar.BorderRadius = 7;
            btnEntrar.CustomizableEdges = customizableEdges2;
            btnEntrar.DisabledState.BorderColor = Color.DarkGray;
            btnEntrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEntrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEntrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEntrar.FillColor = Color.FromArgb(166, 2, 73);
            btnEntrar.Font = new Font("Segoe UI", 9F);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(53, 295);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnEntrar.Size = new Size(349, 38);
            btnEntrar.TabIndex = 13;
            btnEntrar.Text = "Entrar";
            // 
            // pnSeparador
            // 
            pnSeparador.BackColor = Color.White;
            pnSeparador.Location = new Point(12, 102);
            pnSeparador.Name = "pnSeparador";
            pnSeparador.Size = new Size(439, 1);
            pnSeparador.TabIndex = 14;
            // 
            // pnlSeparador2
            // 
            pnlSeparador2.BackColor = Color.White;
            pnlSeparador2.Location = new Point(12, 373);
            pnlSeparador2.Name = "pnlSeparador2";
            pnlSeparador2.Size = new Size(439, 1);
            pnlSeparador2.TabIndex = 15;
            // 
            // lblCarregando
            // 
            lblCarregando.AutoSize = true;
            lblCarregando.Location = new Point(186, 345);
            lblCarregando.Name = "lblCarregando";
            lblCarregando.Size = new Size(81, 15);
            lblCarregando.TabIndex = 16;
            lblCarregando.Text = "Autenticado...";
            // 
            // lblProblemas
            // 
            lblProblemas.AutoSize = true;
            lblProblemas.Location = new Point(27, 388);
            lblProblemas.Name = "lblProblemas";
            lblProblemas.Size = new Size(330, 15);
            lblProblemas.TabIndex = 17;
            lblProblemas.Text = "Problemas para acessar? Contate o administrador do sistema.\r\n";
            // 
            // lblApi
            // 
            lblApi.AutoSize = true;
            lblApi.Location = new Point(27, 414);
            lblApi.Name = "lblApi";
            lblApi.Size = new Size(37, 15);
            lblApi.TabIndex = 18;
            lblApi.Text = "API:...\r\n";
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Location = new Point(133, 468);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(183, 15);
            lblVersao.TabIndex = 19;
            lblVersao.Text = "Versão 0.1.0 | © Hyper Speed Loja";
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(26, 447);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(28, 15);
            lblErro.TabIndex = 20;
            lblErro.Text = "Erro";
            // 
            // lblTextoFacaLogin
            // 
            lblTextoFacaLogin.AutoSize = true;
            lblTextoFacaLogin.Location = new Point(196, 69);
            lblTextoFacaLogin.Name = "lblTextoFacaLogin";
            lblTextoFacaLogin.Size = new Size(141, 15);
            lblTextoFacaLogin.TabIndex = 21;
            lblTextoFacaLogin.Text = "Faça login com seu email";
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(26, 9);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(137, 91);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 24;
            pbLogo.TabStop = false;
            // 
            // btnFechar
            // 
            btnFechar.DisabledState.BorderColor = Color.DarkGray;
            btnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFechar.FillColor = Color.Maroon;
            btnFechar.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(423, 9);
            btnFechar.Name = "btnFechar";
            btnFechar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnFechar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnFechar.Size = new Size(28, 28);
            btnFechar.TabIndex = 25;
            btnFechar.Text = "X";
            btnFechar.Click += btnFechar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            ClientSize = new Size(463, 504);
            Controls.Add(btnFechar);
            Controls.Add(pbLogo);
            Controls.Add(lblTextoFacaLogin);
            Controls.Add(lblErro);
            Controls.Add(lblVersao);
            Controls.Add(lblApi);
            Controls.Add(lblProblemas);
            Controls.Add(lblCarregando);
            Controls.Add(pnlSeparador2);
            Controls.Add(pnSeparador);
            Controls.Add(btnEntrar);
            Controls.Add(lblEmail);
            Controls.Add(lblSenha);
            Controls.Add(lblLoginForm);
            Controls.Add(txtSenha);
            Controls.Add(txtEmail);
            ForeColor = SystemColors.ControlLight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Label lblLoginForm;
        private Guna.UI2.WinForms.Guna2TextBox txtSenha;
        private Label lblSenha;
        private Guna.UI2.WinForms.Guna2Button btnEntrar;
        private Label lblEmail;
        private Panel pnSeparador;
        private Label lblErro;
        private Label lblVersao;
        private Label lblApi;
        private Label lblProblemas;
        private Label lblCarregando;
        private Panel pnlSeparador2;
        private Label lblTextoFacaLogin;
        private PictureBox pbLogo;
        private Guna.UI2.WinForms.Guna2CircleButton btnFechar;
    }
}