namespace StockManager.UI.Forms.Ventas
{
    partial class VentasListForm
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
            this.btnNueva = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.btnHoy = new ToolStripButton();
            this.btnRefrescar = new ToolStripButton();
            this.panelFiltros = new Panel();
            this.btnBuscar = new Button();
            this.dtpHasta = new DateTimePicker();
            this.lblHasta = new Label();
            this.dtpDesde = new DateTimePicker();
            this.lblDesde = new Label();
            this.dgvVentas = new DataGridView();
            this.statusStrip = new StatusStrip();
            this.lblTotalVentas = new ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new Size(20, 20);
            this.toolStrip.Items.AddRange(new ToolStripItem[] {
                this.btnNueva,
                this.toolStripSeparator1,
                this.btnHoy,
                this.btnRefrescar});
            this.toolStrip.Location = new Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(1000, 27);
            this.toolStrip.TabIndex = 0;
            // 
            // btnNueva
            // 
            this.btnNueva.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNueva.Image = null;
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new Size(96, 24);
            this.btnNueva.Text = "Nueva Venta";
            this.btnNueva.Click += this.btnNueva_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 27);
            // 
            // btnHoy
            // 
            this.btnHoy.Image = null;
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new Size(75, 24);
            this.btnHoy.Text = "Hoy";
            this.btnHoy.Click += this.btnHoy_Click;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = null;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new Size(81, 24);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += this.btnRefrescar_Click;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = Color.White;
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Dock = DockStyle.Top;
            this.panelFiltros.Location = new Point(0, 27);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new Padding(10);
            this.panelFiltros.Size = new Size(1000, 60);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = Color.FromArgb(0, 120, 215);
            this.btnBuscar.FlatStyle = FlatStyle.Flat;
            this.btnBuscar.ForeColor = Color.White;
            this.btnBuscar.Location = new Point(620, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(100, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += this.btnBuscar_Click;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new Font("Segoe UI", 10F);
            this.dtpHasta.Format = DateTimePickerFormat.Short;
            this.dtpHasta.Location = new Point(430, 16);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new Size(150, 30);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new Font("Segoe UI", 10F);
            this.lblHasta.Location = new Point(360, 19);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new Size(58, 23);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new Font("Segoe UI", 10F);
            this.dtpDesde.Format = DateTimePickerFormat.Short;
            this.dtpDesde.Location = new Point(180, 16);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new Size(150, 30);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new Font("Segoe UI", 10F);
            this.lblDesde.Location = new Point(13, 19);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new Size(161, 23);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Buscar ventas desde:";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = Color.White;
            this.dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = DockStyle.Fill;
            this.dgvVentas.Location = new Point(0, 87);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 29;
            this.dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new Size(1000, 491);
            this.dgvVentas.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new Size(20, 20);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblTotalVentas});
            this.statusStrip.Location = new Point(0, 578);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1000, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new Size(89, 17);
            this.lblTotalVentas.Text = "Total: $0.00";
            // 
            // VentasListForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.toolStrip);
            this.Name = "VentasListForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ventas";
            this.Load += this.VentasListForm_Load;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton btnNueva;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnHoy;
        private ToolStripButton btnRefrescar;
        private Panel panelFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private DataGridView dgvVentas;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTotalVentas;
    }
}
