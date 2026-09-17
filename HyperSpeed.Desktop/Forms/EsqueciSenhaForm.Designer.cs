namespace HyperSpeed.Desktop.Forms
{
    partial class EsqueciSenhaForm
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
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblEmail = new Label();
            btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            lblLoginForm = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            label1 = new Label();
            label2 = new Label();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.Black;
            txtEmail.BorderRadius = 7;
            txtEmail.CustomizableEdges = customizableEdges1;
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
            txtEmail.Location = new Point(26, 153);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.PlaceholderText = "seuemail@email.com";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(350, 38);
            txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(26, 133);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(125, 17);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Informe seu Email";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Animated = true;
            btnConfirmar.BackColor = Color.Transparent;
            btnConfirmar.BorderColor = Color.Transparent;
            btnConfirmar.BorderRadius = 7;
            btnConfirmar.BorderThickness = 1;
            btnConfirmar.CustomizableEdges = customizableEdges3;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.FillColor = Color.FromArgb(166, 2, 73);
            btnConfirmar.Font = new Font("Segoe UI", 9F);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverState.BorderColor = Color.FromArgb(166, 2, 73);
            btnConfirmar.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnConfirmar.HoverState.ForeColor = Color.FromArgb(166, 2, 73);
            btnConfirmar.Location = new Point(204, 241);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnConfirmar.Size = new Size(172, 38);
            btnConfirmar.TabIndex = 14;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblLoginForm
            // 
            lblLoginForm.AutoSize = true;
            lblLoginForm.Font = new Font("Yu Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginForm.ForeColor = Color.FromArgb(166, 2, 73);
            lblLoginForm.Location = new Point(83, 44);
            lblLoginForm.Name = "lblLoginForm";
            lblLoginForm.Size = new Size(229, 27);
            lblLoginForm.TabIndex = 15;
            lblLoginForm.Text = "Esqueci minha senha";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(83, 81);
            label1.Name = "label1";
            label1.Size = new Size(219, 17);
            label1.TabIndex = 16;
            label1.Text = "Redefina sua senha em 2 etapas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(166, 2, 73);
            label2.Location = new Point(142, 17);
            label2.Name = "label2";
            label2.Size = new Size(136, 27);
            label2.TabIndex = 17;
            label2.Text = "HyperSpeed";
            // 
            // btnCancelar
            // 
            btnCancelar.Animated = true;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.BorderColor = Color.Transparent;
            btnCancelar.BorderRadius = 7;
            btnCancelar.BorderThickness = 1;
            btnCancelar.CustomizableEdges = customizableEdges5;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.Gray;
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.HoverState.BorderColor = Color.Gray;
            btnCancelar.HoverState.FillColor = Color.FromArgb(16, 16, 16);
            btnCancelar.HoverState.ForeColor = Color.Silver;
            btnCancelar.Location = new Point(26, 241);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCancelar.Size = new Size(172, 38);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EsqueciSenhaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            ClientSize = new Size(410, 380);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblLoginForm);
            Controls.Add(btnConfirmar);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EsqueciSenhaForm";
            Text = "EsqueciSenhaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Label lblLoginForm;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}