namespace StockManager.UI.Forms.Ventas
{
    partial class NuevaVentaForm
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
            this.panelTop = new Panel();
            this.cmbCliente = new ComboBox();
            this.lblCliente = new Label();
            this.lblFecha = new Label();
            this.dtpFecha = new DateTimePicker();
            this.panelProductos = new Panel();
            this.btnAgregar = new Button();
            this.numCantidad = new NumericUpDown();
            this.lblCantidad = new Label();
            this.cmbProducto = new ComboBox();
            this.lblProducto = new Label();
            this.lblStockDisponible = new Label();
            this.dgvCarrito = new DataGridView();
            this.panelBottom = new Panel();
            this.btnCancelar = new Button();
            this.btnConfirmar = new Button();
            this.lblTotalValor = new Label();
            this.lblTotal = new Label();
            this.txtObservaciones = new TextBox();
            this.lblObservaciones = new Label();
            this.panelTop.SuspendLayout();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.White;
            this.panelTop.Controls.Add(this.dtpFecha);
            this.panelTop.Controls.Add(this.lblFecha);
            this.panelTop.Controls.Add(this.cmbCliente);
            this.panelTop.Controls.Add(this.lblCliente);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new Padding(10);
            this.panelTop.Size = new Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new Font("Segoe UI", 10F);
            this.dtpFecha.Format = DateTimePickerFormat.Short;
            this.dtpFecha.Location = new Point(620, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new Size(150, 30);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new Font("Segoe UI", 10F);
            this.lblFecha.Location = new Point(550, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new Size(57, 23);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new Font("Segoe UI", 10F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new Point(100, 30);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new Size(400, 31);
            this.cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCliente.Location = new Point(13, 33);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(71, 23);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = Color.FromArgb(240, 240, 240);
            this.panelProductos.Controls.Add(this.lblStockDisponible);
            this.panelProductos.Controls.Add(this.btnAgregar);
            this.panelProductos.Controls.Add(this.numCantidad);
            this.panelProductos.Controls.Add(this.lblCantidad);
            this.panelProductos.Controls.Add(this.cmbProducto);
            this.panelProductos.Controls.Add(this.lblProducto);
            this.panelProductos.Dock = DockStyle.Top;
            this.panelProductos.Location = new Point(0, 80);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Padding = new Padding(10);
            this.panelProductos.Size = new Size(1000, 80);
            this.panelProductos.TabIndex = 1;
            // 
            // lblStockDisponible
            // 
            this.lblStockDisponible.AutoSize = true;
            this.lblStockDisponible.Font = new Font("Segoe UI", 9F);
            this.lblStockDisponible.ForeColor = Color.Green;
            this.lblStockDisponible.Location = new Point(740, 38);
            this.lblStockDisponible.Name = "lblStockDisponible";
            this.lblStockDisponible.Size = new Size(107, 20);
            this.lblStockDisponible.TabIndex = 5;
            this.lblStockDisponible.Text = "Stock: 0 unid.";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = Color.FromArgb(0, 120, 215);
            this.btnAgregar.FlatStyle = FlatStyle.Flat;
            this.btnAgregar.ForeColor = Color.White;
            this.btnAgregar.Location = new Point(870, 28);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(110, 35);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += this.btnAgregar_Click;
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new Font("Segoe UI", 10F);
            this.numCantidad.Location = new Point(620, 30);
            this.numCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new Size(100, 30);
            this.numCantidad.TabIndex = 3;
            this.numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new Font("Segoe UI", 10F);
            this.lblCantidad.Location = new Point(530, 32);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new Size(84, 23);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProducto.Font = new Font("Segoe UI", 10F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new Point(100, 30);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new Size(400, 31);
            this.cmbProducto.TabIndex = 1;
            this.cmbProducto.SelectedIndexChanged += this.cmbProducto_SelectedIndexChanged;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblProducto.Location = new Point(13, 33);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(88, 23);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = Color.White;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Dock = DockStyle.Fill;
            this.dgvCarrito.Location = new Point(0, 160);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.RowTemplate.Height = 29;
            this.dgvCarrito.Size = new Size(1000, 340);
            this.dgvCarrito.TabIndex = 2;
            this.dgvCarrito.KeyDown += this.dgvCarrito_KeyDown;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = Color.White;
            this.panelBottom.Controls.Add(this.lblObservaciones);
            this.panelBottom.Controls.Add(this.txtObservaciones);
            this.panelBottom.Controls.Add(this.btnCancelar);
            this.panelBottom.Controls.Add(this.btnConfirmar);
            this.panelBottom.Controls.Add(this.lblTotalValor);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Location = new Point(0, 500);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new Padding(10);
            this.panelBottom.Size = new Size(1000, 100);
            this.panelBottom.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new Font("Segoe UI", 9F);
            this.lblObservaciones.Location = new Point(13, 13);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new Size(110, 20);
            this.lblObservaciones.TabIndex = 5;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new Point(130, 10);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new Size(400, 80);
            this.txtObservaciones.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(763, 55);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(110, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += this.btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = Color.FromArgb(0, 150, 0);
            this.btnConfirmar.FlatStyle = FlatStyle.Flat;
            this.btnConfirmar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnConfirmar.ForeColor = Color.White;
            this.btnConfirmar.Location = new Point(879, 55);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new Size(110, 35);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += this.btnConfirmar_Click;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTotalValor.ForeColor = Color.FromArgb(0, 120, 215);
            this.lblTotalValor.Location = new Point(650, 10);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new Size(200, 35);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "$0.00";
            this.lblTotalValor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotal.Location = new Point(560, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(84, 32);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL:";
            // 
            // NuevaVentaForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.panelTop);
            this.Name = "NuevaVentaForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nueva Venta";
            this.Load += this.NuevaVentaForm_Load;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelProductos.ResumeLayout(false);
            this.panelProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Panel panelProductos;
        private Label lblProducto;
        private ComboBox cmbProducto;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private Label lblStockDisponible;
        private DataGridView dgvCarrito;
        private Panel panelBottom;
        private Label lblTotal;
        private Label lblTotalValor;
        private Button btnConfirmar;
        private Button btnCancelar;
        private TextBox txtObservaciones;
        private Label lblObservaciones;
    }
}
