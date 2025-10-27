namespace StockManager.UI.Forms.Productos
{
    partial class ProductosListForm
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
            this.toolStrip = new ToolStrip();
            this.btnNuevo = new ToolStripButton();
            this.btnEditar = new ToolStripButton();
            this.btnEliminar = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.btnStockBajo = new ToolStripButton();
            this.btnRefrescar = new ToolStripButton();
            this.panelBusqueda = new Panel();
            this.cmbCategoria = new ComboBox();
            this.lblCategoria = new Label();
            this.btnBuscar = new Button();
            this.txtBuscar = new TextBox();
            this.lblBuscar = new Label();
            this.dgvProductos = new DataGridView();
            this.toolStrip.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new Size(20, 20);
            this.toolStrip.Items.AddRange(new ToolStripItem[] {
                this.btnNuevo,
                this.btnEditar,
                this.btnEliminar,
                this.toolStripSeparator1,
                this.btnStockBajo,
                this.btnRefrescar});
            this.toolStrip.Location = new Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(1200, 27);
            this.toolStrip.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = null;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(62, 24);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += this.btnNuevo_Click;
            // 
            // btnEditar
            // 
            this.btnEditar.Image = null;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new Size(57, 24);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += this.btnEditar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = null;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(74, 24);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += this.btnEliminar_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 27);
            // 
            // btnStockBajo
            // 
            this.btnStockBajo.Image = null;
            this.btnStockBajo.Name = "btnStockBajo";
            this.btnStockBajo.Size = new Size(92, 24);
            this.btnStockBajo.Text = "Stock Bajo";
            this.btnStockBajo.Click += this.btnStockBajo_Click;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = null;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new Size(81, 24);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += this.btnRefrescar_Click;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.BackColor = Color.White;
            this.panelBusqueda.Controls.Add(this.cmbCategoria);
            this.panelBusqueda.Controls.Add(this.lblCategoria);
            this.panelBusqueda.Controls.Add(this.btnBuscar);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Dock = DockStyle.Top;
            this.panelBusqueda.Location = new Point(0, 27);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Padding = new Padding(10);
            this.panelBusqueda.Size = new Size(1200, 60);
            this.panelBusqueda.TabIndex = 1;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new Font("Segoe UI", 10F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new Point(720, 16);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(200, 31);
            this.cmbCategoria.TabIndex = 4;
            this.cmbCategoria.SelectedIndexChanged += this.cmbCategoria_SelectedIndexChanged;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new Font("Segoe UI", 10F);
            this.lblCategoria.Location = new Point(620, 19);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new Size(90, 23);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Categoría:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = Color.FromArgb(0, 120, 215);
            this.btnBuscar.FlatStyle = FlatStyle.Flat;
            this.btnBuscar.ForeColor = Color.White;
            this.btnBuscar.Location = new Point(480, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(100, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += this.btnBuscar_Click;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new Font("Segoe UI", 10F);
            this.txtBuscar.Location = new Point(200, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar por nombre o código...";
            this.txtBuscar.Size = new Size(260, 30);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += this.txtBuscar_KeyPress;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new Font("Segoe UI", 10F);
            this.lblBuscar.Location = new Point(13, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new Size(181, 23);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar por producto:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = DockStyle.Fill;
            this.dgvProductos.Location = new Point(0, 87);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 29;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new Size(1200, 513);
            this.dgvProductos.TabIndex = 2;
            this.dgvProductos.CellDoubleClick += this.dgvProductos_CellDoubleClick;
            this.dgvProductos.CellFormatting += this.dgvProductos_CellFormatting;
            // 
            // ProductosListForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 600);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.toolStrip);
            this.Name = "ProductosListForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Gestión de Productos";
            this.Load += this.ProductosListForm_Load;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnEditar;
        private ToolStripButton btnEliminar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnStockBajo;
        private ToolStripButton btnRefrescar;
        private Panel panelBusqueda;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private DataGridView dgvProductos;
    }
}
