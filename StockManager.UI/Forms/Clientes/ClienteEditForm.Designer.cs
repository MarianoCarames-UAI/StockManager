namespace StockManager.UI.Forms.Clientes
{
    partial class ClienteEditForm
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
            this.panel1 = new Panel();
            this.btnCancelar = new Button();
            this.btnGuardar = new Button();
            this.groupBox1 = new GroupBox();
            this.cmbEstado = new ComboBox();
            this.lblEstado = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.txtTelefono = new TextBox();
            this.lblTelefono = new Label();
            this.txtDireccion = new TextBox();
            this.lblDireccion = new Label();
            this.txtDocumento = new TextBox();
            this.lblDocumento = new Label();
            this.cmbTipoDocumento = new ComboBox();
            this.lblTipoDocumento = new Label();
            this.txtApellido = new TextBox();
            this.lblApellido = new Label();
            this.txtNombre = new TextBox();
            this.lblNombre = new Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 450);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10);
            this.panel1.Size = new Size(600, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(363, 13);
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
            this.btnGuardar.Location = new Point(479, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(110, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += this.btnGuardar_Click;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Controls.Add(this.cmbTipoDocumento);
            this.groupBox1.Controls.Add(this.lblTipoDocumento);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new Font("Segoe UI", 10F);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(20);
            this.groupBox1.Size = new Size(600, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new Point(200, 390);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new Size(370, 31);
            this.cmbEstado.TabIndex = 15;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(30, 393);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(62, 23);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(200, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(370, 30);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(30, 343);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(55, 23);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(200, 290);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(370, 30);
            this.txtTelefono.TabIndex = 11;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(30, 293);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(79, 23);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new Point(200, 240);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new Size(370, 30);
            this.txtDireccion.TabIndex = 9;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new Point(30, 243);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new Size(85, 23);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new Point(200, 190);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new Size(370, 30);
            this.txtDocumento.TabIndex = 7;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new Point(30, 193);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new Size(102, 23);
            this.lblDocumento.TabIndex = 6;
            this.lblDocumento.Text = "Documento:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new Point(200, 140);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new Size(370, 31);
            this.cmbTipoDocumento.TabIndex = 5;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new Point(30, 143);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new Size(142, 23);
            this.lblTipoDocumento.TabIndex = 4;
            this.lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new Point(200, 90);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(370, 30);
            this.txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(30, 93);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(78, 23);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(200, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(370, 30);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(30, 43);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(77, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // ClienteEditForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cliente";
            this.Load += this.ClienteEditForm_Load;
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnGuardar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTipoDocumento;
        private ComboBox cmbTipoDocumento;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEstado;
        private ComboBox cmbEstado;
    }
}
