namespace StockManager.UI.Forms.Admin
{
    partial class EmpleadoEditForm
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
            this.txtNombre = new TextBox();
            this.lblNombre = new Label();
            this.txtApellido = new TextBox();
            this.lblApellido = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.cmbRol = new ComboBox();
            this.lblRol = new Label();
            this.panelPassword = new Panel();
            this.txtPassword = new TextBox();
            this.lblPassword = new Label();
            this.txtConfirmarPassword = new TextBox();
            this.lblConfirmarPassword = new Label();
            this.panel1 = new Panel();
            this.btnCancelar = new Button();
            this.btnGuardar = new Button();
            this.groupBox1.SuspendLayout();
            this.panelPassword.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRol);
            this.groupBox1.Controls.Add(this.cmbRol);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Font = new Font("Segoe UI", 10F);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(15);
            this.groupBox1.Size = new Size(500, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Usuario";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(18, 35);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(73, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new Font("Segoe UI", 10F);
            this.txtNombre.Location = new Point(130, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(340, 30);
            this.txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(18, 75);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(77, 23);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new Font("Segoe UI", 10F);
            this.txtApellido.Location = new Point(130, 72);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(340, 30);
            this.txtApellido.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(18, 115);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(55, 23);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(130, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(340, 30);
            this.txtEmail.TabIndex = 5;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new Point(18, 155);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new Size(38, 23);
            this.lblRol.TabIndex = 6;
            this.lblRol.Text = "Rol:";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.Font = new Font("Segoe UI", 10F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new Point(130, 152);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new Size(340, 31);
            this.cmbRol.TabIndex = 7;
            // 
            // panelPassword
            // 
            this.panelPassword.Controls.Add(this.lblConfirmarPassword);
            this.panelPassword.Controls.Add(this.txtConfirmarPassword);
            this.panelPassword.Controls.Add(this.lblPassword);
            this.panelPassword.Controls.Add(this.txtPassword);
            this.panelPassword.Dock = DockStyle.Top;
            this.panelPassword.Location = new Point(0, 230);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Padding = new Padding(15);
            this.panelPassword.Size = new Size(500, 110);
            this.panelPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 10F);
            this.lblPassword.Location = new Point(18, 20);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(94, 23);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Segoe UI", 10F);
            this.txtPassword.Location = new Point(200, 17);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '?';
            this.txtPassword.Size = new Size(270, 30);
            this.txtPassword.TabIndex = 1;
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new Font("Segoe UI", 10F);
            this.lblConfirmarPassword.Location = new Point(18, 60);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new Size(176, 23);
            this.lblConfirmarPassword.TabIndex = 2;
            this.lblConfirmarPassword.Text = "Confirmar Contraseña:";
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new Font("Segoe UI", 10F);
            this.txtConfirmarPassword.Location = new Point(200, 57);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '?';
            this.txtConfirmarPassword.Size = new Size(270, 30);
            this.txtConfirmarPassword.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10);
            this.panel1.Size = new Size(500, 60);
            this.panel1.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(263, 13);
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
            this.btnGuardar.Location = new Point(379, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(110, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += this.btnGuardar_Click;
            // 
            // EmpleadoEditForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPassword);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmpleadoEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Empleado";
            this.Load += this.EmpleadoEditForm_Load;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRol;
        private ComboBox cmbRol;
        private Panel panelPassword;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmarPassword;
        private TextBox txtConfirmarPassword;
        private Panel panel1;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
