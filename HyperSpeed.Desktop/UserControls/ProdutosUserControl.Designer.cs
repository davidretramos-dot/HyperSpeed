namespace HyperSpeed.Desktop.UserControls
{
    partial class ProdutosUserControl
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
            gridProdutos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategoryName = new DataGridViewTextBoxColumn();
            colReleaseYear = new DataGridViewTextBoxColumn();
            colIsFeatured = new DataGridViewCheckBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            pnlToolbar = new Panel();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnPesquisar = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnNova = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)gridProdutos).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // gridProdutos
            // 
            gridProdutos.BackgroundColor = Color.FromArgb(15, 15, 15);
            gridProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProdutos.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colCategoryName, colReleaseYear, colIsFeatured, colCreatedAt });
            gridProdutos.Location = new Point(18, 165);
            gridProdutos.Name = "gridProdutos";
            gridProdutos.Size = new Size(768, 316);
            gridProdutos.TabIndex = 9;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Título";
            colTitle.Name = "colTitle";
            colTitle.Width = 225;
            // 
            // colCategoryName
            // 
            colCategoryName.HeaderText = "Categoria";
            colCategoryName.Name = "colCategoryName";
            // 
            // colReleaseYear
            // 
            colReleaseYear.HeaderText = "Ano";
            colReleaseYear.Name = "colReleaseYear";
            // 
            // colIsFeatured
            // 
            colIsFeatured.HeaderText = "Destaque";
            colIsFeatured.Name = "colIsFeatured";
            colIsFeatured.Resizable = DataGridViewTriState.True;
            colIsFeatured.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colCreatedAt
            // 
            colCreatedAt.HeaderText = "Cadastrado em";
            colCreatedAt.Name = "colCreatedAt";
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(txtPesquisa);
            pnlToolbar.Controls.Add(btnPesquisar);
            pnlToolbar.Controls.Add(btnAtualizar);
            pnlToolbar.Controls.Add(btnExcluir);
            pnlToolbar.Controls.Add(btnEditar);
            pnlToolbar.Controls.Add(btnNova);
            pnlToolbar.Location = new Point(18, 59);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(768, 100);
            pnlToolbar.TabIndex = 8;
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderColor = Color.FromArgb(166, 2, 73);
            txtPesquisa.BorderRadius = 5;
            txtPesquisa.CustomizableEdges = customizableEdges1;
            txtPesquisa.DefaultText = "🔎 Pesquisar por título...";
            txtPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.FillColor = Color.FromArgb(15, 15, 15);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.ForeColor = Color.White;
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Location = new Point(13, 28);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPesquisa.Size = new Size(253, 36);
            txtPesquisa.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BorderRadius = 10;
            btnPesquisar.CustomizableEdges = customizableEdges3;
            btnPesquisar.DisabledState.BorderColor = Color.DarkGray;
            btnPesquisar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPesquisar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPesquisar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPesquisar.FillColor = Color.RoyalBlue;
            btnPesquisar.Font = new Font("Segoe UI", 9F);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.Location = new Point(272, 25);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPesquisar.Size = new Size(93, 44);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Text = "🔎 Pesquisar";
            btnPesquisar.Click += btnPesquisar_Click;
            btnPesquisar.KeyUp += btnPesquisar_KeyUp;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BorderRadius = 10;
            btnAtualizar.CustomizableEdges = customizableEdges5;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.Goldenrod;
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(659, 25);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAtualizar.Size = new Size(90, 41);
            btnAtualizar.TabIndex = 1;
            btnAtualizar.Text = "🔄️ Atualizar";

            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 10;
            btnExcluir.CustomizableEdges = customizableEdges7;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.Maroon;
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(563, 25);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnExcluir.Size = new Size(90, 41);
            btnExcluir.TabIndex = 1;
            btnExcluir.Text = "🗑️ Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 10;
            btnEditar.CustomizableEdges = customizableEdges9;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.DarkBlue;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(467, 25);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnEditar.Size = new Size(90, 41);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✏️ Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNova
            // 
            btnNova.BorderRadius = 10;
            btnNova.CustomizableEdges = customizableEdges11;
            btnNova.DisabledState.BorderColor = Color.DarkGray;
            btnNova.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNova.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNova.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNova.FillColor = Color.DarkGreen;
            btnNova.Font = new Font("Segoe UI", 9F);
            btnNova.ForeColor = Color.White;
            btnNova.Location = new Point(371, 25);
            btnNova.Name = "btnNova";
            btnNova.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnNova.Size = new Size(90, 41);
            btnNova.TabIndex = 1;
            btnNova.Text = "+ Novo Game";
            btnNova.Click += btnNova_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(166, 2, 73);
            lblTitulo.Location = new Point(18, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(268, 25);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = " Gerenciamento de Produtos";
            // 
            // ProdutosUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            Controls.Add(gridProdutos);
            Controls.Add(pnlToolbar);
            Controls.Add(lblTitulo);
            Name = "ProdutosUserControl";
            Size = new Size(805, 501);
            ((System.ComponentModel.ISupportInitialize)gridProdutos).EndInit();
            pnlToolbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridProdutos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colCategoryName;
        private DataGridViewTextBoxColumn colReleaseYear;
        private DataGridViewCheckBoxColumn colIsFeatured;
        private DataGridViewTextBoxColumn colCreatedAt;
        private Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnPesquisar;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnNova;
        private Label lblTitulo;
    }
}
