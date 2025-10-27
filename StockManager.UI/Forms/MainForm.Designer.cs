namespace StockManager.UI.Forms
{
    partial class MainForm
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
            this.menuStrip = new MenuStrip();
            this.menuItemVentas = new ToolStripMenuItem();
            this.menuItemClientes = new ToolStripMenuItem();
            this.menuItemProductos = new ToolStripMenuItem();
            this.menuItemStock = new ToolStripMenuItem();
            this.menuItemReportes = new ToolStripMenuItem();
            this.menuItemAdmin = new ToolStripMenuItem();
            this.menuItemIdioma = new ToolStripMenuItem();
            this.menuItemCerrarSesion = new ToolStripMenuItem();
            this.menuItemSalir = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.lblUsuarioInfo = new ToolStripStatusLabel();
            this.panelCentral = new Panel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new Size(20, 20);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.menuItemVentas,
                this.menuItemClientes,
                this.menuItemProductos,
                this.menuItemStock,
                this.menuItemReportes,
                this.menuItemAdmin,
                this.menuItemIdioma,
                this.menuItemCerrarSesion,
                this.menuItemSalir
            });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(1200, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuItemVentas
            // 
            this.menuItemVentas.Name = "menuItemVentas";
            this.menuItemVentas.Size = new Size(69, 24);
            this.menuItemVentas.Text = "Ventas";
            this.menuItemVentas.Click += this.menuItemVentas_Click;
            // 
            // menuItemClientes
            // 
            this.menuItemClientes.Name = "menuItemClientes";
            this.menuItemClientes.Size = new Size(79, 24);
            this.menuItemClientes.Text = "Clientes";
            this.menuItemClientes.Click += this.menuItemClientes_Click;
            // 
            // menuItemProductos
            // 
            this.menuItemProductos.Name = "menuItemProductos";
            this.menuItemProductos.Size = new Size(92, 24);
            this.menuItemProductos.Text = "Productos";
            this.menuItemProductos.Click += this.menuItemProductos_Click;
            // 
            // menuItemStock
            // 
            this.menuItemStock.Name = "menuItemStock";
            this.menuItemStock.Size = new Size(61, 24);
            this.menuItemStock.Text = "Stock";
            this.menuItemStock.Click += this.menuItemStock_Click;
            // 
            // menuItemReportes
            // 
            this.menuItemReportes.Name = "menuItemReportes";
            this.menuItemReportes.Size = new Size(84, 24);
            this.menuItemReportes.Text = "Reportes";
            this.menuItemReportes.Click += this.menuItemReportes_Click;
            // 
            // menuItemAdmin
            // 
            this.menuItemAdmin.Name = "menuItemAdmin";
            this.menuItemAdmin.Size = new Size(74, 24);
            this.menuItemAdmin.Text = "Admin";
            this.menuItemAdmin.Click += this.menuItemAdmin_Click;
            // 
            // menuItemIdioma
            // 
            this.menuItemIdioma.Name = "menuItemIdioma";
            this.menuItemIdioma.Size = new Size(71, 24);
            this.menuItemIdioma.Text = "Idioma";
            // 
            // menuItemCerrarSesion
            // 
            this.menuItemCerrarSesion.Name = "menuItemCerrarSesion";
            this.menuItemCerrarSesion.Size = new Size(117, 24);
            this.menuItemCerrarSesion.Text = "Cerrar Sesión";
            this.menuItemCerrarSesion.Click += this.menuItemCerrarSesion_Click;
            // 
            // menuItemSalir
            // 
            this.menuItemSalir.Name = "menuItemSalir";
            this.menuItemSalir.Size = new Size(52, 24);
            this.menuItemSalir.Text = "Salir";
            this.menuItemSalir.Click += this.menuItemSalir_Click;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new Size(20, 20);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblUsuarioInfo
            });
            this.statusStrip.Location = new Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1200, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblUsuarioInfo
            // 
            this.lblUsuarioInfo.Name = "lblUsuarioInfo";
            this.lblUsuarioInfo.Size = new Size(150, 17);
            this.lblUsuarioInfo.Text = "Usuario: -";
            // 
            // panelCentral
            // 
            this.panelCentral.Dock = DockStyle.Fill;
            this.panelCentral.Location = new Point(0, 28);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new Size(1200, 700);
            this.panelCentral.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 750);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "StockManager v2.0";
            this.WindowState = FormWindowState.Maximized;
            this.Load += this.MainForm_Load;
            this.FormClosing += this.MainForm_FormClosing;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuItemVentas;
        private ToolStripMenuItem menuItemClientes;
        private ToolStripMenuItem menuItemProductos;
        private ToolStripMenuItem menuItemStock;
        private ToolStripMenuItem menuItemReportes;
        private ToolStripMenuItem menuItemAdmin;
        private ToolStripMenuItem menuItemIdioma;
        private ToolStripMenuItem menuItemCerrarSesion;
        private ToolStripMenuItem menuItemSalir;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUsuarioInfo;
        private Panel panelCentral;
    }
}
