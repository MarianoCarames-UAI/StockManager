namespace StockManager.UI.Forms
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
            panelMain = new Panel();
            cmbLanguage = new ComboBox();
            lblLanguage = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            lblPassword = new Label();
            lblEmail = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(lblSubtitle);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(44, 38);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(350, 300);
            panelMain.TabIndex = 0;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.Font = new Font("Segoe UI", 10F);
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(54, 342);
            cmbLanguage.Margin = new Padding(3, 2, 3, 2);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(88, 25);
            cmbLanguage.TabIndex = 0;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 9F);
            lblLanguage.Location = new Point(1, 347);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(47, 15);
            lblLanguage.TabIndex = 8;
            lblLanguage.Text = "Idioma:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(44, 248);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(262, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(44, 202);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '?';
            txtPassword.Size = new Size(263, 27);
            txtPassword.TabIndex = 3;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(44, 135);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(263, 27);
            txtEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(44, 184);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 19);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Contraseña";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(44, 116);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(44, 49);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(222, 15);
            lblSubtitle.TabIndex = 5;
            lblSubtitle.Text = "Sistema Integral de Gestión de Inventario";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitle.Location = new Point(44, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "StockManager v2.0";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(438, 375);
            Controls.Add(cmbLanguage);
            Controls.Add(panelMain);
            Controls.Add(lblLanguage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockManager - Iniciar Sesión";
            Load += LoginForm_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMain;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
    }
}
