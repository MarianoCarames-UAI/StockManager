namespace StockManager.UI.Forms.Productos
{
    partial class ProductoEditForm
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
            this.numStockMinimo = new NumericUpDown();
            this.lblStockMinimo = new Label();
            this.numStockInicial = new NumericUpDown();
            this.lblStockInicial = new Label();
            this.numCosto = new NumericUpDown();
            this.lblCosto = new Label();
            this.numPrecio = new NumericUpDown();
            this.lblPrecio = new Label();
            this.cmbCategoria = new ComboBox();
            this.lblCategoria = new Label();
            this.txtDescripcion = new TextBox();
            this.lblDescripcion = new Label();
            this.txtNombre = new TextBox();
            this.lblNombre = new Label();
            this.txtCodigo = new TextBox();
            this.lblCodigo = new Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10);
            this.panel1.Size = new Size(700, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(463, 13);
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
            this.btnGuardar.Location = new Point(579, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(110, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += this.btnGuardar_Click;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numStockMinimo);
            this.groupBox1.Controls.Add(this.lblStockMinimo);
            this.groupBox1.Controls.Add(this.numStockInicial);
            this.groupBox1.Controls.Add(this.lblStockInicial);
            this.groupBox1.Controls.Add(this.numCosto);
            this.groupBox1.Controls.Add(this.lblCosto);
            this.groupBox1.Controls.Add(this.numPrecio);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Controls.Add(this.lblCategoria);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new Font("Segoe UI", 10F);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(20);
            this.groupBox1.Size = new Size(700, 520);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Producto";
            // 
            // numStockMinimo
            // 
            this.numStockMinimo.Location = new Point(470, 440);
            this.numStockMinimo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numStockMinimo.Name = "numStockMinimo";
            this.numStockMinimo.Size = new Size(200, 30);
            this.numStockMinimo.TabIndex = 15;
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Location = new Point(360, 442);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new Size(115, 23);
            this.lblStockMinimo.TabIndex = 14;
            this.lblStockMinimo.Text = "Stock Mínimo:";
            // 
            // numStockInicial
            // 
            this.numStockInicial.Location = new Point(160, 440);
            this.numStockInicial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numStockInicial.Name = "numStockInicial";
            this.numStockInicial.Size = new Size(180, 30);
            this.numStockInicial.TabIndex = 13;
            // 
            // lblStockInicial
            // 
            this.lblStockInicial.AutoSize = true;
            this.lblStockInicial.Location = new Point(30, 442);
            this.lblStockInicial.Name = "lblStockInicial";
            this.lblStockInicial.Size = new Size(107, 23);
            this.lblStockInicial.TabIndex = 12;
            this.lblStockInicial.Text = "Stock Inicial:";
            // 
            // numCosto
            // 
            this.numCosto.DecimalPlaces = 2;
            this.numCosto.Location = new Point(470, 390);
            this.numCosto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numCosto.Name = "numCosto";
            this.numCosto.Size = new Size(200, 30);
            this.numCosto.TabIndex = 11;
            this.numCosto.ThousandsSeparator = true;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new Point(360, 392);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new Size(59, 23);
            this.lblCosto.TabIndex = 10;
            this.lblCosto.Text = "Costo:";
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new Point(160, 390);
            this.numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new Size(180, 30);
            this.numPrecio.TabIndex = 9;
            this.numPrecio.ThousandsSeparator = true;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new Point(30, 392);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new Size(62, 23);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new Point(160, 190);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(510, 31);
            this.cmbCategoria.TabIndex = 7;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new Point(30, 193);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new Size(90, 23);
            this.lblCategoria.TabIndex = 6;
            this.lblCategoria.Text = "Categoría:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(160, 240);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = ScrollBars.Vertical;
            this.txtDescripcion.Size = new Size(510, 120);
            this.txtDescripcion.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new Point(30, 243);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(104, 23);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(160, 140);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(510, 30);
            this.txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(30, 143);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(77, 23);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = CharacterCasing.Upper;
            this.txtCodigo.Location = new Point(160, 90);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Size(200, 30);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new Point(30, 93);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new Size(70, 23);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // ProductoEditForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 580);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Producto";
            this.Load += this.ProductoEditForm_Load;
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnGuardar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Label lblCosto;
        private NumericUpDown numCosto;
        private Label lblStockInicial;
        private NumericUpDown numStockInicial;
        private Label lblStockMinimo;
        private NumericUpDown numStockMinimo;
    }
}
