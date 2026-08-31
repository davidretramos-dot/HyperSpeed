namespace HyperSpeed.Desktop.UserControls
{
    partial class DashboardUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gridUltimosGames = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategoryName = new DataGridViewTextBoxColumn();
            colReleaseYear = new DataGridViewTextBoxColumn();
            colIsFeatured = new DataGridViewCheckBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            pnlCorCategorias = new Guna.UI2.WinForms.Guna2Panel();
            cardCategorias = new Guna.UI2.WinForms.Guna2Panel();
            cardCategoriasLblNumero = new Label();
            cardCategoriasLblTitulo = new Label();
            cardCategoriasLblDesc = new Label();
            cardGames = new Guna.UI2.WinForms.Guna2Panel();
            pnlCorGames = new Guna.UI2.WinForms.Guna2Panel();
            cardGamesLblDesc = new Label();
            cardGamesLblNumero = new Label();
            cardGamesLblTitulo = new Label();
            lblUltimosGames = new Label();
            lblCarregando = new Label();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)gridUltimosGames).BeginInit();
            cardCategorias.SuspendLayout();
            cardGames.SuspendLayout();
            SuspendLayout();
            // 
            // gridUltimosGames
            // 
            gridUltimosGames.BackgroundColor = Color.FromArgb(15, 15, 15);
            gridUltimosGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUltimosGames.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colCategoryName, colReleaseYear, colIsFeatured, colCreatedAt });
            gridUltimosGames.Location = new Point(21, 269);
            gridUltimosGames.Name = "gridUltimosGames";
            gridUltimosGames.Size = new Size(770, 217);
            gridUltimosGames.TabIndex = 11;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Width = 50;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Título";
            colTitle.Name = "colTitle";
            colTitle.Width = 150;
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
            // 
            // colCreatedAt
            // 
            colCreatedAt.HeaderText = "Cadastrado em";
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.Resizable = DataGridViewTriState.True;
            colCreatedAt.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlCorCategorias
            // 
            pnlCorCategorias.CustomizableEdges = customizableEdges1;
            pnlCorCategorias.FillColor = Color.FromArgb(166, 2, 73);
            pnlCorCategorias.Location = new Point(251, 96);
            pnlCorCategorias.Name = "pnlCorCategorias";
            pnlCorCategorias.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlCorCategorias.Size = new Size(210, 10);
            pnlCorCategorias.TabIndex = 10;
            // 
            // cardCategorias
            // 
            cardCategorias.BorderColor = Color.FromArgb(166, 2, 73);
            cardCategorias.BorderRadius = 10;
            cardCategorias.BorderThickness = 2;
            cardCategorias.Controls.Add(cardCategoriasLblNumero);
            cardCategorias.Controls.Add(cardCategoriasLblTitulo);
            cardCategorias.Controls.Add(cardCategoriasLblDesc);
            cardCategorias.CustomizableEdges = customizableEdges3;
            cardCategorias.FillColor = Color.FromArgb(15, 15, 15);
            cardCategorias.Location = new Point(251, 96);
            cardCategorias.Name = "cardCategorias";
            cardCategorias.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cardCategorias.Size = new Size(210, 120);
            cardCategorias.TabIndex = 8;
            // 
            // cardCategoriasLblNumero
            // 
            cardCategoriasLblNumero.AutoSize = true;
            cardCategoriasLblNumero.BackColor = Color.Transparent;
            cardCategoriasLblNumero.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardCategoriasLblNumero.ForeColor = Color.White;
            cardCategoriasLblNumero.Location = new Point(20, 38);
            cardCategoriasLblNumero.Name = "cardCategoriasLblNumero";
            cardCategoriasLblNumero.Size = new Size(38, 45);
            cardCategoriasLblNumero.TabIndex = 2;
            cardCategoriasLblNumero.Text = "0";
            // 
            // cardCategoriasLblTitulo
            // 
            cardCategoriasLblTitulo.AutoSize = true;
            cardCategoriasLblTitulo.BackColor = Color.Transparent;
            cardCategoriasLblTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            cardCategoriasLblTitulo.ForeColor = Color.FromArgb(166, 2, 73);
            cardCategoriasLblTitulo.Location = new Point(20, 19);
            cardCategoriasLblTitulo.Name = "cardCategoriasLblTitulo";
            cardCategoriasLblTitulo.Size = new Size(117, 19);
            cardCategoriasLblTitulo.TabIndex = 1;
            cardCategoriasLblTitulo.Text = "🏷️ Categorias";
            // 
            // cardCategoriasLblDesc
            // 
            cardCategoriasLblDesc.AutoSize = true;
            cardCategoriasLblDesc.BackColor = Color.Transparent;
            cardCategoriasLblDesc.Font = new Font("Century Gothic", 8.25F);
            cardCategoriasLblDesc.ForeColor = SystemColors.ControlDark;
            cardCategoriasLblDesc.Location = new Point(20, 83);
            cardCategoriasLblDesc.Name = "cardCategoriasLblDesc";
            cardCategoriasLblDesc.Size = new Size(111, 16);
            cardCategoriasLblDesc.TabIndex = 0;
            cardCategoriasLblDesc.Text = "Total de categorias";
            // 
            // cardGames
            // 
            cardGames.BorderColor = Color.FromArgb(166, 2, 73);
            cardGames.BorderRadius = 10;
            cardGames.BorderThickness = 2;
            cardGames.Controls.Add(pnlCorGames);
            cardGames.Controls.Add(cardGamesLblDesc);
            cardGames.Controls.Add(cardGamesLblNumero);
            cardGames.Controls.Add(cardGamesLblTitulo);
            cardGames.CustomizableEdges = customizableEdges7;
            cardGames.FillColor = Color.FromArgb(15, 15, 15);
            cardGames.Location = new Point(14, 96);
            cardGames.Name = "cardGames";
            cardGames.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cardGames.Size = new Size(210, 120);
            cardGames.TabIndex = 9;
            // 
            // pnlCorGames
            // 
            pnlCorGames.CustomizableEdges = customizableEdges5;
            pnlCorGames.FillColor = Color.FromArgb(166, 2, 73);
            pnlCorGames.Location = new Point(0, 0);
            pnlCorGames.Name = "pnlCorGames";
            pnlCorGames.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlCorGames.Size = new Size(210, 10);
            pnlCorGames.TabIndex = 2;
            // 
            // cardGamesLblDesc
            // 
            cardGamesLblDesc.AutoSize = true;
            cardGamesLblDesc.BackColor = Color.Transparent;
            cardGamesLblDesc.Font = new Font("Century Gothic", 8.25F);
            cardGamesLblDesc.ForeColor = SystemColors.ControlDark;
            cardGamesLblDesc.Location = new Point(12, 83);
            cardGamesLblDesc.Name = "cardGamesLblDesc";
            cardGamesLblDesc.Size = new Size(162, 16);
            cardGamesLblDesc.TabIndex = 3;
            cardGamesLblDesc.Text = "Total de games cadastrados";
            // 
            // cardGamesLblNumero
            // 
            cardGamesLblNumero.AutoSize = true;
            cardGamesLblNumero.BackColor = Color.Transparent;
            cardGamesLblNumero.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardGamesLblNumero.ForeColor = Color.White;
            cardGamesLblNumero.Location = new Point(12, 38);
            cardGamesLblNumero.Name = "cardGamesLblNumero";
            cardGamesLblNumero.Size = new Size(38, 45);
            cardGamesLblNumero.TabIndex = 2;
            cardGamesLblNumero.Text = "0";
            // 
            // cardGamesLblTitulo
            // 
            cardGamesLblTitulo.AutoSize = true;
            cardGamesLblTitulo.BackColor = Color.Transparent;
            cardGamesLblTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            cardGamesLblTitulo.ForeColor = Color.FromArgb(166, 2, 73);
            cardGamesLblTitulo.Location = new Point(12, 19);
            cardGamesLblTitulo.Name = "cardGamesLblTitulo";
            cardGamesLblTitulo.Size = new Size(98, 19);
            cardGamesLblTitulo.TabIndex = 1;
            cardGamesLblTitulo.Text = "\U0001f6d2 Produtos";
            // 
            // lblUltimosGames
            // 
            lblUltimosGames.AutoSize = true;
            lblUltimosGames.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUltimosGames.ForeColor = Color.White;
            lblUltimosGames.Location = new Point(14, 241);
            lblUltimosGames.Name = "lblUltimosGames";
            lblUltimosGames.Size = new Size(250, 19);
            lblUltimosGames.TabIndex = 4;
            lblUltimosGames.Text = "💾 Últimos Produtos cadastrados";
            // 
            // lblCarregando
            // 
            lblCarregando.AutoSize = true;
            lblCarregando.Font = new Font("Century Gothic", 10F);
            lblCarregando.ForeColor = Color.FromArgb(166, 2, 73);
            lblCarregando.Location = new Point(14, 64);
            lblCarregando.Name = "lblCarregando";
            lblCarregando.Size = new Size(221, 19);
            lblCarregando.TabIndex = 5;
            lblCarregando.Text = "⌛Carregando dados da API...";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Century Gothic", 10F);
            lblSubtitulo.ForeColor = SystemColors.ControlDark;
            lblSubtitulo.Location = new Point(14, 38);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(262, 19);
            lblSubtitulo.TabIndex = 6;
            lblSubtitulo.Text = "Bem-vindo ao SenacGames Desktop";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(14, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(77, 23);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Olá! 👋";
            // 
            // DashboardUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            Controls.Add(gridUltimosGames);
            Controls.Add(pnlCorCategorias);
            Controls.Add(cardCategorias);
            Controls.Add(cardGames);
            Controls.Add(lblUltimosGames);
            Controls.Add(lblCarregando);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            Name = "DashboardUserControl";
            Size = new Size(805, 501);
            ((System.ComponentModel.ISupportInitialize)gridUltimosGames).EndInit();
            cardCategorias.ResumeLayout(false);
            cardCategorias.PerformLayout();
            cardGames.ResumeLayout(false);
            cardGames.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridUltimosGames;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colCategoryName;
        private DataGridViewTextBoxColumn colReleaseYear;
        private DataGridViewCheckBoxColumn colIsFeatured;
        private DataGridViewTextBoxColumn colCreatedAt;
        private Guna.UI2.WinForms.Guna2Panel pnlCorCategorias;
        private Guna.UI2.WinForms.Guna2Panel cardCategorias;
        private Label cardCategoriasLblNumero;
        private Label cardCategoriasLblTitulo;
        private Label cardCategoriasLblDesc;
        private Guna.UI2.WinForms.Guna2Panel cardGames;
        private Guna.UI2.WinForms.Guna2Panel pnlCorGames;
        private Label cardGamesLblDesc;
        private Label cardGamesLblNumero;
        private Label cardGamesLblTitulo;
        private Label lblUltimosGames;
        private Label lblCarregando;
        private Label lblSubtitulo;
        private Label lblTitulo;
    }
}
