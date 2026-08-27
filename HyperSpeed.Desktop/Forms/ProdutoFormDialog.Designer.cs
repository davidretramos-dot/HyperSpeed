namespace HyperSpeed.Desktop.Forms
{
    partial class ProdutoFormDialog
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            chkDestaque = new CheckBox();
            lblCampTitulo = new Label();
            lblCampDesc = new Label();
            lblCampPreco = new Label();
            lblCampCover = new Label();
            lblCampCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblTituloForm = new Label();
            txtDescricao = new Guna.UI2.WinForms.Guna2TextBox();
            txtPreco = new Guna.UI2.WinForms.Guna2TextBox();
            txtCoverUrl = new Guna.UI2.WinForms.Guna2TextBox();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 7;
            btnCancelar.CustomizableEdges = customizableEdges13;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.FromArgb(64, 64, 64);
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(172, 531);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnCancelar.Size = new Size(113, 45);
            btnCancelar.TabIndex = 42;
            btnCancelar.Text = "Cancelar\r\n";
            // 
            // btnSalvar
            // 
            btnSalvar.BorderRadius = 7;
            btnSalvar.CustomizableEdges = customizableEdges15;
            btnSalvar.DisabledState.BorderColor = Color.DarkGray;
            btnSalvar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSalvar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSalvar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSalvar.FillColor = Color.DarkGreen;
            btnSalvar.Font = new Font("Segoe UI", 9F);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(24, 531);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSalvar.Size = new Size(131, 45);
            btnSalvar.TabIndex = 41;
            btnSalvar.Text = "Salvar";
            // 
            // chkDestaque
            // 
            chkDestaque.AutoSize = true;
            chkDestaque.ForeColor = Color.FromArgb(224, 224, 224);
            chkDestaque.Location = new Point(24, 497);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(151, 19);
            chkDestaque.TabIndex = 40;
            chkDestaque.Text = " * Produto em destaque";
            chkDestaque.UseVisualStyleBackColor = true;
            // 
            // lblCampTitulo
            // 
            lblCampTitulo.AutoSize = true;
            lblCampTitulo.ForeColor = Color.White;
            lblCampTitulo.Location = new Point(24, 72);
            lblCampTitulo.Name = "lblCampTitulo";
            lblCampTitulo.Size = new Size(103, 15);
            lblCampTitulo.TabIndex = 39;
            lblCampTitulo.Text = "Nome do Produto";
            // 
            // lblCampDesc
            // 
            lblCampDesc.AutoSize = true;
            lblCampDesc.ForeColor = Color.White;
            lblCampDesc.Location = new Point(23, 145);
            lblCampDesc.Name = "lblCampDesc";
            lblCampDesc.Size = new Size(58, 15);
            lblCampDesc.TabIndex = 38;
            lblCampDesc.Text = "Descrição";
            // 
            // lblCampPreco
            // 
            lblCampPreco.AutoSize = true;
            lblCampPreco.ForeColor = Color.White;
            lblCampPreco.Location = new Point(24, 265);
            lblCampPreco.Name = "lblCampPreco";
            lblCampPreco.Size = new Size(37, 15);
            lblCampPreco.TabIndex = 37;
            lblCampPreco.Text = "Preço";
            // 
            // lblCampCover
            // 
            lblCampCover.AutoSize = true;
            lblCampCover.ForeColor = Color.White;
            lblCampCover.Location = new Point(24, 330);
            lblCampCover.Name = "lblCampCover";
            lblCampCover.Size = new Size(154, 15);
            lblCampCover.TabIndex = 36;
            lblCampCover.Text = "URL da imagem do produto";
            // 
            // lblCampCategoria
            // 
            lblCampCategoria.AutoSize = true;
            lblCampCategoria.ForeColor = Color.White;
            lblCampCategoria.Location = new Point(24, 424);
            lblCampCategoria.Name = "lblCampCategoria";
            lblCampCategoria.Size = new Size(66, 15);
            lblCampCategoria.TabIndex = 35;
            lblCampCategoria.Text = "Categoria *";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(24, 442);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(480, 23);
            cmbCategoria.TabIndex = 33;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.ForeColor = Color.FromArgb(166, 2, 73);
            lblTituloForm.Location = new Point(24, 29);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(71, 21);
            lblTituloForm.TabIndex = 34;
            lblTituloForm.Text = "Produto";
            // 
            // txtDescricao
            // 
            txtDescricao.BorderColor = Color.Black;
            txtDescricao.BorderRadius = 7;
            txtDescricao.CustomizableEdges = customizableEdges17;
            txtDescricao.DefaultText = "";
            txtDescricao.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDescricao.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDescricao.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDescricao.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDescricao.FillColor = Color.FromArgb(16, 16, 16);
            txtDescricao.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescricao.Font = new Font("Segoe UI", 9F);
            txtDescricao.ForeColor = Color.FromArgb(224, 224, 224);
            txtDescricao.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescricao.Location = new Point(23, 163);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "";
            txtDescricao.SelectedText = "";
            txtDescricao.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtDescricao.Size = new Size(481, 92);
            txtDescricao.TabIndex = 32;
            // 
            // txtPreco
            // 
            txtPreco.BorderColor = Color.Black;
            txtPreco.BorderRadius = 7;
            txtPreco.CustomizableEdges = customizableEdges19;
            txtPreco.DefaultText = "R$";
            txtPreco.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPreco.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPreco.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPreco.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPreco.FillColor = Color.FromArgb(16, 16, 16);
            txtPreco.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPreco.Font = new Font("Segoe UI", 9F);
            txtPreco.ForeColor = Color.FromArgb(224, 224, 224);
            txtPreco.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPreco.Location = new Point(24, 283);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "";
            txtPreco.SelectedText = "";
            txtPreco.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtPreco.Size = new Size(481, 36);
            txtPreco.TabIndex = 31;
            // 
            // txtCoverUrl
            // 
            txtCoverUrl.BorderColor = Color.Black;
            txtCoverUrl.BorderRadius = 7;
            txtCoverUrl.CustomizableEdges = customizableEdges21;
            txtCoverUrl.DefaultText = "";
            txtCoverUrl.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCoverUrl.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCoverUrl.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCoverUrl.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCoverUrl.FillColor = Color.FromArgb(16, 16, 16);
            txtCoverUrl.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCoverUrl.Font = new Font("Segoe UI", 9F);
            txtCoverUrl.ForeColor = Color.FromArgb(224, 224, 224);
            txtCoverUrl.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCoverUrl.Location = new Point(23, 348);
            txtCoverUrl.Name = "txtCoverUrl";
            txtCoverUrl.PlaceholderText = "";
            txtCoverUrl.SelectedText = "";
            txtCoverUrl.ShadowDecoration.CustomizableEdges = customizableEdges22;
            txtCoverUrl.Size = new Size(481, 36);
            txtCoverUrl.TabIndex = 30;
            // 
            // txtTitulo
            // 
            txtTitulo.BorderColor = Color.Black;
            txtTitulo.BorderRadius = 7;
            txtTitulo.CustomizableEdges = customizableEdges23;
            txtTitulo.DefaultText = "";
            txtTitulo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTitulo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTitulo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTitulo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTitulo.FillColor = Color.FromArgb(16, 16, 16);
            txtTitulo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTitulo.Font = new Font("Segoe UI", 9F);
            txtTitulo.ForeColor = Color.FromArgb(224, 224, 224);
            txtTitulo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTitulo.Location = new Point(23, 90);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "";
            txtTitulo.SelectedText = "";
            txtTitulo.ShadowDecoration.CustomizableEdges = customizableEdges24;
            txtTitulo.Size = new Size(481, 36);
            txtTitulo.TabIndex = 29;
            // 
            // ProdutoFormDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            ClientSize = new Size(531, 596);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(chkDestaque);
            Controls.Add(lblCampTitulo);
            Controls.Add(lblCampDesc);
            Controls.Add(lblCampPreco);
            Controls.Add(lblCampCover);
            Controls.Add(lblCampCategoria);
            Controls.Add(cmbCategoria);
            Controls.Add(lblTituloForm);
            Controls.Add(txtDescricao);
            Controls.Add(txtPreco);
            Controls.Add(txtCoverUrl);
            Controls.Add(txtTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProdutoFormDialog";
            Text = "ProdutoFormDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private CheckBox chkDestaque;
        private Label lblCampTitulo;
        private Label lblCampDesc;
        private Label lblCampPreco;
        private Label lblCampCover;
        private Label lblCampCategoria;
        private ComboBox cmbCategoria;
        private Label lblTituloForm;
        private Guna.UI2.WinForms.Guna2TextBox txtDescricao;
        private Guna.UI2.WinForms.Guna2TextBox txtPreco;
        private Guna.UI2.WinForms.Guna2TextBox txtCoverUrl;
        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;
    }
}