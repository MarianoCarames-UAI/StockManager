namespace StockManager.UI.Forms.Clientes
{
    partial class ClientesListForm
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
            this.btnRefrescar = new ToolStripButton();
            this.panelBusqueda = new Panel();
            this.btnBuscar = new Button();
            this.txtBuscar = new TextBox();
            this.lblBuscar = new Label();
            this.dgvClientes = new DataGridView();
            this.toolStrip.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
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
                this.btnRefrescar});
            this.toolStrip.Location = new Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(1000, 27);
            this.toolStrip.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = null;
            this.btnNuevo.ImageTransparentColor = Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(62, 24);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += this.btnNuevo_Click;
            // 
            // btnEditar
            // 
            this.btnEditar.Image = null;
            this.btnEditar.ImageTransparentColor = Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new Size(57, 24);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += this.btnEditar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = null;
            this.btnEliminar.ImageTransparentColor = Color.Magenta;
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
            // btnRefrescar
            // 
            this.btnRefrescar.Image = null;
            this.btnRefrescar.ImageTransparentColor = Color.Magenta;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new Size(81, 24);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += this.btnRefrescar_Click;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.BackColor = Color.White;
            this.panelBusqueda.Controls.Add(this.btnBuscar);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Dock = DockStyle.Top;
            this.panelBusqueda.Location = new Point(0, 27);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Padding = new Padding(10);
            this.panelBusqueda.Size = new Size(1000, 60);
            this.panelBusqueda.TabIndex = 1;
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
            this.txtBuscar.Location = new Point(180, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new Size(280, 30);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += this.txtBuscar_KeyPress;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new Font("Segoe UI", 10F);
            this.lblBuscar.Location = new Point(13, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new Size(161, 23);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar por nombre:";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = Color.White;
            this.dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Dock = DockStyle.Fill;
            this.dgvClientes.Location = new Point(0, 87);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 29;
            this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new Size(1000, 513);
            this.dgvClientes.TabIndex = 2;
            this.dgvClientes.CellDoubleClick += this.dgvClientes_CellDoubleClick;
            // 
            // ClientesListForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.toolStrip);
            this.Name = "ClientesListForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Gestión de Clientes";
            this.Load += this.ClientesListForm_Load;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnEditar;
        private ToolStripButton btnEliminar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnRefrescar;
        private Panel panelBusqueda;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
    }
}
