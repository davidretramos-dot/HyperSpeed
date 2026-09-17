namespace HyperSpeed.Desktop.UserControls
{
    partial class InfoUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoUserControl));
            lblNomeProj = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblDescricaoProj = new Label();
            label1 = new Label();
            lblFuncao = new Label();
            label3 = new Label();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblNomeProj
            // 
            lblNomeProj.BackColor = Color.Transparent;
            lblNomeProj.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeProj.ForeColor = Color.FromArgb(166, 2, 73);
            lblNomeProj.Location = new Point(13, 17);
            lblNomeProj.Name = "lblNomeProj";
            lblNomeProj.Size = new Size(157, 23);
            lblNomeProj.TabIndex = 5;
            lblNomeProj.Text = "Projeto: HyperSpeed";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.imagem__1_;
            pictureBox2.Location = new Point(699, 368);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 86);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.imagem__3_;
            pictureBox1.Location = new Point(577, 368);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblDescricaoProj
            // 
            lblDescricaoProj.AutoSize = true;
            lblDescricaoProj.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescricaoProj.ForeColor = Color.White;
            lblDescricaoProj.Location = new Point(13, 53);
            lblDescricaoProj.Name = "lblDescricaoProj";
            lblDescricaoProj.Size = new Size(661, 60);
            lblDescricaoProj.TabIndex = 8;
            lblDescricaoProj.Text = resources.GetString("lblDescricaoProj.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 132);
            label1.Name = "label1";
            label1.Size = new Size(392, 40);
            label1.TabIndex = 9;
            label1.Text = "Somos nós:\r\nCauã Farias, Davi Ramos, João Roberto e Natan Gonçalves\r\n";
            // 
            // lblFuncao
            // 
            lblFuncao.AutoSize = true;
            lblFuncao.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFuncao.ForeColor = Color.White;
            lblFuncao.Location = new Point(13, 187);
            lblFuncao.Name = "lblFuncao";
            lblFuncao.Size = new Size(568, 80);
            lblFuncao.TabIndex = 10;
            lblFuncao.Text = resources.GetString("lblFuncao.Text");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(13, 401);
            label3.Name = "label3";
            label3.Size = new Size(60, 40);
            label3.TabIndex = 11;
            label3.Text = "Projeto:\r\n\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(13, 338);
            label4.Name = "label4";
            label4.Size = new Size(523, 40);
            label4.TabIndex = 12;
            label4.Text = "Tecnologias:\r\nC#, JavaScript, HTML, CSS, Guna2.UI, Bootstrap, SQL Server e Entity Framework\r\n";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Turquoise;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.FromArgb(166, 2, 73);
            linkLabel1.Location = new Point(13, 421);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(383, 20);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/davidretramos-dot/HyperSpeed.git";
            linkLabel1.VisitedLinkColor = Color.SteelBlue;
            // 
            // InfoUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblFuncao);
            Controls.Add(label1);
            Controls.Add(lblDescricaoProj);
            Controls.Add(lblNomeProj);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "InfoUserControl";
            Size = new Size(786, 457);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblNomeProj;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblDescricaoProj;
        private Label label1;
        private Label lblFuncao;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
    }
}
