namespace StockManager.UI.Forms.Stock
{
    partial class StockForm
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
            this.dgvStock = new DataGridView();
            this.toolStrip = new ToolStrip();
            this.btnRefrescar = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.btnEditarStock = new ToolStripButton();
            this.btnStockBajo = new ToolStripButton();
            this.btnExportar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.BackgroundColor = Color.White;
            this.dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Dock = DockStyle.Fill;
            this.dgvStock.Location = new Point(0, 27);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.RowTemplate.Height = 29;
            this.dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new Size(1000, 573);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellFormatting += this.dgvStock_CellFormatting;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new Size(20, 20);
            this.toolStrip.Items.AddRange(new ToolStripItem[] {
            this.btnRefrescar,
            this.toolStripSeparator1,
            this.btnEditarStock,
            this.btnStockBajo,
            this.btnExportar});
            this.toolStrip.Location = new Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(1000, 27);
            this.toolStrip.TabIndex = 1;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = null;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new Size(81, 24);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += this.btnRefrescar_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 27);
            // 
            // btnEditarStock
            // 
            this.btnEditarStock.Image = null;
            this.btnEditarStock.Name = "btnEditarStock";
            this.btnEditarStock.Size = new Size(100, 24);
            this.btnEditarStock.Text = "Editar Stock";
            this.btnEditarStock.Click += this.btnEditarStock_Click;
            // 
            // btnStockBajo
            // 
            this.btnStockBajo.Image = null;
            this.btnStockBajo.Name = "btnStockBajo";
            this.btnStockBajo.Size = new Size(92, 24);
            this.btnStockBajo.Text = "Stock Bajo";
            this.btnStockBajo.Click += this.btnStockBajo_Click;
            // 
            // btnExportar
            // 
            this.btnExportar.Image = null;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new Size(112, 24);
            this.btnExportar.Text = "Exportar CSV";
            this.btnExportar.Click += this.btnExportar_Click;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.toolStrip);
            this.Name = "StockForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Consulta de Stock";
            this.Load += this.StockForm_Load;
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dgvStock;
        private ToolStrip toolStrip;
        private ToolStripButton btnRefrescar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnEditarStock;
        private ToolStripButton btnStockBajo;
        private ToolStripButton btnExportar;
    }
}
