namespace StockManager.UI.Forms.Stock
{
    partial class EditarStockForm
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
            this.lblProducto = new Label();
            this.lblProductoNombre = new Label();
            this.lblStockActualLabel = new Label();
            this.lblStockActual = new Label();
            this.lblStockMinLabel = new Label();
            this.lblStockMin = new Label();
            this.numNuevoStock = new NumericUpDown();
            this.lblNuevoStock = new Label();
            this.txtMotivo = new TextBox();
            this.lblMotivo = new Label();
            this.panel1 = new Panel();
            this.btnCancelar = new Button();
            this.btnGuardar = new Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNuevoStock)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMotivo);
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Controls.Add(this.lblNuevoStock);
            this.groupBox1.Controls.Add(this.numNuevoStock);
            this.groupBox1.Controls.Add(this.lblStockMin);
            this.groupBox1.Controls.Add(this.lblStockMinLabel);
            this.groupBox1.Controls.Add(this.lblStockActual);
            this.groupBox1.Controls.Add(this.lblStockActualLabel);
            this.groupBox1.Controls.Add(this.lblProductoNombre);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new Font("Segoe UI", 10F);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(20);
            this.groupBox1.Size = new Size(500, 380);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editar Stock";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblProducto.Location = new Point(23, 40);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(88, 23);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.AutoSize = true;
            this.lblProductoNombre.ForeColor = Color.FromArgb(0, 120, 215);
            this.lblProductoNombre.Location = new Point(117, 40);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new Size(48, 23);
            this.lblProductoNombre.TabIndex = 1;
            this.lblProductoNombre.Text = "PROD-001";
            // 
            // lblStockActualLabel
            // 
            this.lblStockActualLabel.AutoSize = true;
            this.lblStockActualLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStockActualLabel.Location = new Point(23, 90);
            this.lblStockActualLabel.Name = "lblStockActualLabel";
            this.lblStockActualLabel.Size = new Size(116, 23);
            this.lblStockActualLabel.TabIndex = 2;
            this.lblStockActualLabel.Text = "Stock Actual:";
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStockActual.ForeColor = Color.Green;
            this.lblStockActual.Location = new Point(145, 90);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new Size(31, 23);
            this.lblStockActual.TabIndex = 3;
            this.lblStockActual.Text = "50";
            // 
            // lblStockMinLabel
            // 
            this.lblStockMinLabel.AutoSize = true;
            this.lblStockMinLabel.Location = new Point(23, 130);
            this.lblStockMinLabel.Name = "lblStockMinLabel";
            this.lblStockMinLabel.Size = new Size(115, 23);
            this.lblStockMinLabel.TabIndex = 4;
            this.lblStockMinLabel.Text = "Stock Mínimo:";
            // 
            // lblStockMin
            // 
            this.lblStockMin.AutoSize = true;
            this.lblStockMin.Location = new Point(145, 130);
            this.lblStockMin.Name = "lblStockMin";
            this.lblStockMin.Size = new Size(23, 23);
            this.lblStockMin.TabIndex = 5;
            this.lblStockMin.Text = "10";
            // 
            // numNuevoStock
            // 
            this.numNuevoStock.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.numNuevoStock.Location = new Point(200, 180);
            this.numNuevoStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numNuevoStock.Name = "numNuevoStock";
            this.numNuevoStock.Size = new Size(150, 34);
            this.numNuevoStock.TabIndex = 6;
            // 
            // lblNuevoStock
            // 
            this.lblNuevoStock.AutoSize = true;
            this.lblNuevoStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNuevoStock.Location = new Point(23, 185);
            this.lblNuevoStock.Name = "lblNuevoStock";
            this.lblNuevoStock.Size = new Size(124, 23);
            this.lblNuevoStock.TabIndex = 7;
            this.lblNuevoStock.Text = "Nuevo Stock:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new Point(23, 265);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.PlaceholderText = "Ej: Ajuste de inventario, error de conteo, etc.";
            this.txtMotivo.Size = new Size(450, 80);
            this.txtMotivo.TabIndex = 8;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new Point(23, 235);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new Size(182, 23);
            this.lblMotivo.TabIndex = 9;
            this.lblMotivo.Text = "Motivo del Ajuste:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 380);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10);
            this.panel1.Size = new Size(500, 60);
            this.panel1.TabIndex = 1;
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
            // EditarStockForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 440);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarStockForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Editar Stock";
            this.Load += this.EditarStockForm_Load;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNuevoStock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private Label lblProducto;
        private Label lblProductoNombre;
        private Label lblStockActualLabel;
        private Label lblStockActual;
        private Label lblStockMinLabel;
        private Label lblStockMin;
        private NumericUpDown numNuevoStock;
        private Label lblNuevoStock;
        private TextBox txtMotivo;
        private Label lblMotivo;
        private Panel panel1;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
