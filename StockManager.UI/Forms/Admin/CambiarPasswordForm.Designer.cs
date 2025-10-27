namespace StockManager.UI.Forms.Admin
{
    partial class CambiarPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.lblUsuario = new Label();
            this.lblUsuarioInfo = new Label();
            this.lblNuevoPassword = new Label();
            this.txtNuevoPassword = new TextBox();
            this.lblConfirmarPassword = new Label();
            this.txtConfirmarPassword = new TextBox();
            this.panel1 = new Panel();
            this.btnCancelar = new Button();
            this.btnGuardar = new Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfirmarPassword);
            this.groupBox1.Controls.Add(this.lblConfirmarPassword);
            this.groupBox1.Controls.Add(this.txtNuevoPassword);
            this.groupBox1.Controls.Add(this.lblNuevoPassword);
            this.groupBox1.Controls.Add(this.lblUsuarioInfo);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new Font("Segoe UI", 10F);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(15);
            this.groupBox1.Size = new Size(450, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambiar Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblUsuario.Location = new Point(18, 35);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(74, 23);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblUsuarioInfo
            // 
            this.lblUsuarioInfo.AutoSize = true;
            this.lblUsuarioInfo.ForeColor = Color.FromArgb(0, 120, 215);
            this.lblUsuarioInfo.Location = new Point(98, 35);
            this.lblUsuarioInfo.Name = "lblUsuarioInfo";
            this.lblUsuarioInfo.Size = new Size(200, 23);
            this.lblUsuarioInfo.TabIndex = 1;
            this.lblUsuarioInfo.Text = "Juan Pérez (juan@mail.com)";
            // 
            // lblNuevoPassword
            // 
            this.lblNuevoPassword.AutoSize = true;
            this.lblNuevoPassword.Location = new Point(18, 90);
            this.lblNuevoPassword.Name = "lblNuevoPassword";
            this.lblNuevoPassword.Size = new Size(155, 23);
            this.lblNuevoPassword.TabIndex = 2;
            this.lblNuevoPassword.Text = "Nueva Contraseña:";
            // 
            // txtNuevoPassword
            // 
            this.txtNuevoPassword.Font = new Font("Segoe UI", 10F);
            this.txtNuevoPassword.Location = new Point(18, 116);
            this.txtNuevoPassword.Name = "txtNuevoPassword";
            this.txtNuevoPassword.PasswordChar = '?';
            this.txtNuevoPassword.Size = new Size(400, 30);
            this.txtNuevoPassword.TabIndex = 3;
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Location = new Point(18, 155);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new Size(185, 23);
            this.lblConfirmarPassword.TabIndex = 4;
            this.lblConfirmarPassword.Text = "Confirmar Contraseña:";
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new Font("Segoe UI", 10F);
            this.txtConfirmarPassword.Location = new Point(18, 181);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '?';
            this.txtConfirmarPassword.Size = new Size(400, 30);
            this.txtConfirmarPassword.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10);
            this.panel1.Size = new Size(450, 60);
            this.panel1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(213, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(110, 35);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += this.btnCancelar_Click;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Color.FromArgb(0, 120, 215);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(329, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(110, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += this.btnGuardar_Click;
            // 
            // CambiarPasswordForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(450, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambiarPasswordForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cambiar Contraseña";
            this.Load += this.CambiarPasswordForm_Load;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private Label lblUsuario;
        private Label lblUsuarioInfo;
        private Label lblNuevoPassword;
        private TextBox txtNuevoPassword;
        private Label lblConfirmarPassword;
        private TextBox txtConfirmarPassword;
        private Panel panel1;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
