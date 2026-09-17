namespace HyperSpeed.Desktop.Forms
{
    partial class MainForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlSidebar = new Panel();
            btnInfoProj = new Guna.UI2.WinForms.Guna2Button();
            btnPerfil = new Guna.UI2.WinForms.Guna2Button();
            btnUsuarios = new Guna.UI2.WinForms.Guna2Button();
            btnCategorias = new Guna.UI2.WinForms.Guna2Button();
            btnProdutos = new Guna.UI2.WinForms.Guna2Button();
            lblSessao = new Label();
            btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            pnlUsuario = new Panel();
            lblPerfil = new Label();
            lblUsuario = new Label();
            pnlLogo = new Panel();
            lblSidebarSub = new Label();
            lblSidebarLogo = new Label();
            pnlConteudo = new Panel();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            lblTituloApp = new Label();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            pnlHeader = new Panel();
            pnlSidebar.SuspendLayout();
            pnlUsuario.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(21, 21, 21);
            pnlSidebar.Controls.Add(btnInfoProj);
            pnlSidebar.Controls.Add(btnPerfil);
            pnlSidebar.Controls.Add(btnUsuarios);
            pnlSidebar.Controls.Add(btnCategorias);
            pnlSidebar.Controls.Add(btnProdutos);
            pnlSidebar.Controls.Add(lblSessao);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Location = new Point(3, 157);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 448);
            pnlSidebar.TabIndex = 1;
            // 
            // btnInfoProj
            // 
            btnInfoProj.Animated = true;
            btnInfoProj.BackColor = Color.Transparent;
            btnInfoProj.BorderColor = Color.Transparent;
            btnInfoProj.BorderRadius = 5;
            btnInfoProj.BorderThickness = 1;
            btnInfoProj.CheckedState.FillColor = Color.Transparent;
            btnInfoProj.CustomizableEdges = customizableEdges1;
            btnInfoProj.DisabledState.BorderColor = Color.DarkGray;
            btnInfoProj.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInfoProj.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInfoProj.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInfoProj.FillColor = Color.FromArgb(166, 2, 73);
            btnInfoProj.Font = new Font("Segoe UI", 9F);
            btnInfoProj.ForeColor = Color.White;
            btnInfoProj.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnInfoProj.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnInfoProj.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnInfoProj.Location = new Point(0, 264);
            btnInfoProj.Name = "btnInfoProj";
            btnInfoProj.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnInfoProj.Size = new Size(200, 24);
            btnInfoProj.TabIndex = 6;
            btnInfoProj.Text = "Sobre o Projeto";
            btnInfoProj.Click += btnInfoProj_Click;
            // 
            // btnPerfil
            // 
            btnPerfil.Animated = true;
            btnPerfil.BackColor = Color.Transparent;
            btnPerfil.BorderColor = Color.Transparent;
            btnPerfil.BorderRadius = 5;
            btnPerfil.BorderThickness = 1;
            btnPerfil.CheckedState.FillColor = Color.Transparent;
            btnPerfil.CustomizableEdges = customizableEdges3;
            btnPerfil.DisabledState.BorderColor = Color.DarkGray;
            btnPerfil.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPerfil.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPerfil.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPerfil.FillColor = Color.FromArgb(166, 2, 73);
            btnPerfil.Font = new Font("Segoe UI", 9F);
            btnPerfil.ForeColor = Color.White;
            btnPerfil.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnPerfil.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnPerfil.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnPerfil.Location = new Point(0, 111);
            btnPerfil.Name = "btnPerfil";
            btnPerfil.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPerfil.Size = new Size(200, 45);
            btnPerfil.TabIndex = 5;
            btnPerfil.Text = "Meu Perfil";
            btnPerfil.Click += btnPerfil_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Animated = true;
            btnUsuarios.BackColor = Color.Transparent;
            btnUsuarios.BorderColor = Color.Transparent;
            btnUsuarios.BorderRadius = 5;
            btnUsuarios.BorderThickness = 1;
            btnUsuarios.CheckedState.FillColor = Color.Transparent;
            btnUsuarios.CustomizableEdges = customizableEdges5;
            btnUsuarios.DisabledState.BorderColor = Color.DarkGray;
            btnUsuarios.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUsuarios.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUsuarios.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUsuarios.FillColor = Color.FromArgb(166, 2, 73);
            btnUsuarios.Font = new Font("Segoe UI", 9F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnUsuarios.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnUsuarios.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnUsuarios.Location = new Point(0, 162);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUsuarios.Size = new Size(200, 45);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Animated = true;
            btnCategorias.BackColor = Color.Transparent;
            btnCategorias.BorderColor = Color.Transparent;
            btnCategorias.BorderRadius = 5;
            btnCategorias.BorderThickness = 1;
            btnCategorias.CheckedState.FillColor = Color.Transparent;
            btnCategorias.CustomizableEdges = customizableEdges7;
            btnCategorias.DisabledState.BorderColor = Color.DarkGray;
            btnCategorias.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCategorias.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCategorias.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCategorias.FillColor = Color.FromArgb(166, 2, 73);
            btnCategorias.Font = new Font("Segoe UI", 9F);
            btnCategorias.ForeColor = Color.White;
            btnCategorias.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnCategorias.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnCategorias.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnCategorias.Location = new Point(0, 213);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCategorias.Size = new Size(200, 45);
            btnCategorias.TabIndex = 3;
            btnCategorias.Text = "Categorias";
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.Animated = true;
            btnProdutos.BackColor = Color.Transparent;
            btnProdutos.BorderColor = Color.Transparent;
            btnProdutos.BorderRadius = 5;
            btnProdutos.BorderThickness = 1;
            btnProdutos.CheckedState.FillColor = Color.Transparent;
            btnProdutos.CustomizableEdges = customizableEdges9;
            btnProdutos.DisabledState.BorderColor = Color.DarkGray;
            btnProdutos.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProdutos.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProdutos.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProdutos.FillColor = Color.FromArgb(166, 2, 73);
            btnProdutos.Font = new Font("Segoe UI", 9F);
            btnProdutos.ForeColor = Color.White;
            btnProdutos.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnProdutos.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnProdutos.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnProdutos.Location = new Point(0, 60);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnProdutos.Size = new Size(200, 45);
            btnProdutos.TabIndex = 2;
            btnProdutos.Text = "Produtos";
            btnProdutos.Click += btnProdutos_Click;
            // 
            // lblSessao
            // 
            lblSessao.AutoSize = true;
            lblSessao.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            lblSessao.ForeColor = Color.FromArgb(166, 2, 73);
            lblSessao.Location = new Point(12, 425);
            lblSessao.Name = "lblSessao";
            lblSessao.Size = new Size(16, 16);
            lblSessao.TabIndex = 0;
            lblSessao.Text = "...";
            // 
            // btnDashboard
            // 
            btnDashboard.Animated = true;
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.BorderColor = Color.Transparent;
            btnDashboard.BorderRadius = 5;
            btnDashboard.BorderThickness = 1;
            btnDashboard.CheckedState.FillColor = Color.Transparent;
            btnDashboard.CustomizableEdges = customizableEdges11;
            btnDashboard.DisabledState.BorderColor = Color.DarkGray;
            btnDashboard.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDashboard.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDashboard.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDashboard.FillColor = Color.FromArgb(166, 2, 73);
            btnDashboard.Font = new Font("Segoe UI", 9F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnDashboard.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnDashboard.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnDashboard.Location = new Point(0, 9);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDashboard.Size = new Size(200, 45);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlUsuario
            // 
            pnlUsuario.BackColor = Color.FromArgb(21, 21, 21);
            pnlUsuario.Controls.Add(lblPerfil);
            pnlUsuario.Controls.Add(lblUsuario);
            pnlUsuario.Location = new Point(3, 3);
            pnlUsuario.Name = "pnlUsuario";
            pnlUsuario.Size = new Size(200, 100);
            pnlUsuario.TabIndex = 7;
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPerfil.ForeColor = Color.FromArgb(166, 2, 73);
            lblPerfil.Location = new Point(15, 43);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(37, 17);
            lblPerfil.TabIndex = 0;
            lblPerfil.Text = "Perfil";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(166, 2, 73);
            lblUsuario.Location = new Point(9, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(106, 23);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "\U0001f9d1‍💼 Usuário";
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(15, 15, 15);
            pnlLogo.Controls.Add(lblSidebarSub);
            pnlLogo.Controls.Add(lblSidebarLogo);
            pnlLogo.Location = new Point(3, 104);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(200, 60);
            pnlLogo.TabIndex = 8;
            // 
            // lblSidebarSub
            // 
            lblSidebarSub.AutoSize = true;
            lblSidebarSub.BackColor = Color.Transparent;
            lblSidebarSub.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSidebarSub.ForeColor = Color.FromArgb(166, 2, 73);
            lblSidebarSub.Location = new Point(15, 33);
            lblSidebarSub.Name = "lblSidebarSub";
            lblSidebarSub.Size = new Size(126, 17);
            lblSidebarSub.TabIndex = 0;
            lblSidebarSub.Text = "Plataforma Desktop";
            // 
            // lblSidebarLogo
            // 
            lblSidebarLogo.AutoSize = true;
            lblSidebarLogo.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSidebarLogo.ForeColor = Color.FromArgb(166, 2, 73);
            lblSidebarLogo.Location = new Point(15, 10);
            lblSidebarLogo.Name = "lblSidebarLogo";
            lblSidebarLogo.Size = new Size(126, 23);
            lblSidebarLogo.TabIndex = 0;
            lblSidebarLogo.Text = "HYPER SPEED";
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.FromArgb(15, 15, 15);
            pnlConteudo.Location = new Point(209, 109);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(802, 496);
            pnlConteudo.TabIndex = 9;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lblTituloApp
            // 
            lblTituloApp.AutoSize = true;
            lblTituloApp.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloApp.ForeColor = Color.White;
            lblTituloApp.Location = new Point(21, 37);
            lblTituloApp.Name = "lblTituloApp";
            lblTituloApp.Size = new Size(173, 23);
            lblTituloApp.TabIndex = 0;
            lblTituloApp.Text = "Hyper Speed Loja";
            // 
            // btnLogout
            // 
            btnLogout.Animated = true;
            btnLogout.BorderColor = Color.Transparent;
            btnLogout.BorderRadius = 5;
            btnLogout.BorderThickness = 1;
            btnLogout.CustomizableEdges = customizableEdges13;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = Color.Maroon;
            btnLogout.Font = new Font("Segoe UI", 9F);
            btnLogout.ForeColor = Color.White;
            btnLogout.HoverState.BorderColor = Color.Maroon;
            btnLogout.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnLogout.HoverState.ForeColor = Color.Red;
            btnLogout.Location = new Point(693, 37);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnLogout.Size = new Size(90, 33);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Sair";
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 15, 15);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(lblTituloApp);
            pnlHeader.Location = new Point(209, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(802, 100);
            pnlHeader.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            ClientSize = new Size(1023, 613);
            Controls.Add(pnlHeader);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlLogo);
            Controls.Add(pnlUsuario);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblSessao;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Panel pnlUsuario;
        private Panel pnlLogo;
        private Label lblSidebarSub;
        private Label lblSidebarLogo;
        private Label lblPerfil;
        private Label lblUsuario;
        private Panel pnlConteudo;
        private Guna.UI2.WinForms.Guna2Button btnPerfil;
        private Guna.UI2.WinForms.Guna2Button btnUsuarios;
        private Guna.UI2.WinForms.Guna2Button btnCategorias;
        private Guna.UI2.WinForms.Guna2Button btnProdutos;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Label lblTituloApp;
        private Guna.UI2.WinForms.Guna2Button btnInfoProj;
    }
}