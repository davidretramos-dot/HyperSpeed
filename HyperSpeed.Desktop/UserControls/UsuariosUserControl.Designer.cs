namespace HyperSpeed.Desktop.UserControls
{
    partial class UsuariosUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
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
            gridUsuarios = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPerfil = new DataGridViewTextBoxColumn();
            pnlToolbar = new Panel();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnPesquisar = new Guna.UI2.WinForms.Guna2Button();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)gridUsuarios).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // gridUsuarios
            // 
            gridUsuarios.AllowUserToAddRows = false;
            gridUsuarios.AllowUserToDeleteRows = false;
            gridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUsuarios.BackgroundColor = Color.FromArgb(15, 15, 15);
            gridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colEmail, colPerfil });
            gridUsuarios.Location = new Point(22, 118);
            gridUsuarios.Margin = new Padding(3, 2, 3, 2);
            gridUsuarios.Name = "gridUsuarios";
            gridUsuarios.ReadOnly = true;
            gridUsuarios.RowHeadersVisible = false;
            gridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsuarios.Size = new Size(831, 328);
            gridUsuarios.TabIndex = 3;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNome
            // 
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPerfil
            // 
            colPerfil.HeaderText = "Perfil";
            colPerfil.Name = "colPerfil";
            colPerfil.ReadOnly = true;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(15, 15, 15);
            pnlToolbar.Controls.Add(txtPesquisa);
            pnlToolbar.Controls.Add(btnPesquisar);
            pnlToolbar.Controls.Add(btnNovo);
            pnlToolbar.Controls.Add(btnEditar);
            pnlToolbar.Controls.Add(btnExcluir);
            pnlToolbar.Controls.Add(btnAtualizar);
            pnlToolbar.Location = new Point(22, 51);
            pnlToolbar.Margin = new Padding(3, 2, 3, 2);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(7, 6, 7, 6);
            pnlToolbar.Size = new Size(831, 53);
            pnlToolbar.TabIndex = 4;
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderColor = Color.FromArgb(166, 2, 73);
            txtPesquisa.BorderRadius = 6;
            txtPesquisa.CustomizableEdges = customizableEdges1;
            txtPesquisa.DefaultText = "";
            txtPesquisa.FillColor = Color.FromArgb(15, 15, 15);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.Location = new Point(7, 6);
            txtPesquisa.Margin = new Padding(3, 2, 3, 2);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "Pesquisar por nome ou email...";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPesquisa.Size = new Size(325, 39);
            txtPesquisa.TabIndex = 0;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Animated = true;
            btnPesquisar.BorderColor = Color.Transparent;
            btnPesquisar.BorderRadius = 6;
            btnPesquisar.BorderThickness = 1;
            btnPesquisar.CustomizableEdges = customizableEdges3;
            btnPesquisar.FillColor = Color.FromArgb(43, 112, 255);
            btnPesquisar.Font = new Font("Segoe UI", 9F);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.HoverState.BorderColor = Color.FromArgb(43, 112, 255);
            btnPesquisar.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnPesquisar.HoverState.ForeColor = Color.FromArgb(43, 112, 255);
            btnPesquisar.Location = new Point(338, 6);
            btnPesquisar.Margin = new Padding(3, 2, 3, 2);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPesquisar.Size = new Size(40, 39);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Text = "🔍";
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Animated = true;
            btnNovo.BorderColor = Color.Transparent;
            btnNovo.BorderRadius = 6;
            btnNovo.BorderThickness = 1;
            btnNovo.CustomizableEdges = customizableEdges5;
            btnNovo.FillColor = Color.DarkGreen;
            btnNovo.Font = new Font("Segoe UI", 9F);
            btnNovo.ForeColor = Color.White;
            btnNovo.HoverState.BorderColor = Color.DarkGreen;
            btnNovo.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnNovo.HoverState.ForeColor = Color.Green;
            btnNovo.Location = new Point(384, 6);
            btnNovo.Margin = new Padding(3, 2, 3, 2);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnNovo.Size = new Size(79, 39);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "Novo";
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Animated = true;
            btnEditar.BorderColor = Color.Transparent;
            btnEditar.BorderRadius = 6;
            btnEditar.BorderThickness = 1;
            btnEditar.CustomizableEdges = customizableEdges7;
            btnEditar.FillColor = Color.DarkBlue;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.DarkBlue;
            btnEditar.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnEditar.HoverState.ForeColor = Color.RoyalBlue;
            btnEditar.Location = new Point(469, 6);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEditar.Size = new Size(79, 39);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Animated = true;
            btnExcluir.BorderColor = Color.Transparent;
            btnExcluir.BorderRadius = 6;
            btnExcluir.BorderThickness = 1;
            btnExcluir.CustomizableEdges = customizableEdges9;
            btnExcluir.FillColor = Color.Maroon;
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.HoverState.BorderColor = Color.Maroon;
            btnExcluir.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnExcluir.HoverState.ForeColor = Color.Red;
            btnExcluir.Location = new Point(554, 6);
            btnExcluir.Margin = new Padding(3, 2, 3, 2);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnExcluir.Size = new Size(79, 39);
            btnExcluir.TabIndex = 4;
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Animated = true;
            btnAtualizar.BorderColor = Color.Transparent;
            btnAtualizar.BorderRadius = 6;
            btnAtualizar.BorderThickness = 1;
            btnAtualizar.CustomizableEdges = customizableEdges11;
            btnAtualizar.FillColor = Color.Goldenrod;
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.HoverState.BorderColor = Color.Goldenrod;
            btnAtualizar.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnAtualizar.HoverState.ForeColor = Color.Yellow;
            btnAtualizar.Location = new Point(639, 6);
            btnAtualizar.Margin = new Padding(3, 2, 3, 2);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnAtualizar.Size = new Size(79, 39);
            btnAtualizar.TabIndex = 5;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(166, 2, 73);
            lblTitulo.Location = new Point(22, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(438, 27);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "👤 Gerenciamento de Usuários";
            // 
            // UsuariosUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            Controls.Add(gridUsuarios);
            Controls.Add(pnlToolbar);
            Controls.Add(lblTitulo);
            Name = "UsuariosUserControl";
            Size = new Size(875, 465);
            Load += UsuariosUserControl_Load_1;
            ((System.ComponentModel.ISupportInitialize)gridUsuarios).EndInit();
            pnlToolbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridUsuarios;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPerfil;
        private Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnPesquisar;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Label lblTitulo;
        
    }
}
