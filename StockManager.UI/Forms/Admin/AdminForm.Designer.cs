namespace StockManager.UI.Forms.Admin
{
    partial class AdminForm
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
            this.btnNuevoUsuario = new ToolStripButton();
            this.btnEditarUsuario = new ToolStripButton();
            this.btnCambiarPassword = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.btnRefrescar = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.lblSeccion = new ToolStripLabel();
            this.cmbSeccion = new ToolStripComboBox();
            this.panelInfo = new Panel();
            this.lblInfo = new Label();
            this.dgvDatos = new DataGridView();
            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new Size(20, 20);
            this.toolStrip.Items.AddRange(new ToolStripItem[] {
                this.btnNuevoUsuario,
                this.btnEditarUsuario,
                this.btnCambiarPassword,
                this.toolStripSeparator1,
                this.btnRefrescar,
                this.toolStripSeparator2,
                this.lblSeccion,
                this.cmbSeccion});
            this.toolStrip.Location = new Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(1000, 27);
            this.toolStrip.TabIndex = 0;
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.Image = null;
            this.btnNuevoUsuario.ImageTransparentColor = Color.Magenta;
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new Size(107, 24);
            this.btnNuevoUsuario.Text = "Nuevo Usuario";
            this.btnNuevoUsuario.Click += this.btnNuevoUsuario_Click;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Image = null;
            this.btnEditarUsuario.ImageTransparentColor = Color.Magenta;
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new Size(102, 24);
            this.btnEditarUsuario.Text = "Editar Usuario";
            this.btnEditarUsuario.Click += this.btnEditarUsuario_Click;
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.Image = null;
            this.btnCambiarPassword.ImageTransparentColor = Color.Magenta;
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new Size(133, 24);
            this.btnCambiarPassword.Text = "Cambiar Contraseña";
            this.btnCambiarPassword.Click += this.btnCambiarPassword_Click;
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 27);
            // 
            // lblSeccion
            // 
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new Size(63, 24);
            this.lblSeccion.Text = "Sección:";
            // 
            // cmbSeccion
            // 
            this.cmbSeccion.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSeccion.Name = "cmbSeccion";
            this.cmbSeccion.Size = new Size(150, 27);
            this.cmbSeccion.SelectedIndexChanged += this.cmbSeccion_SelectedIndexChanged;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = Color.White;
            this.panelInfo.Controls.Add(this.lblInfo);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new Point(0, 27);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new Padding(10);
            this.panelInfo.Size = new Size(1000, 60);
            this.panelInfo.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblInfo.Location = new Point(13, 19);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(318, 23);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Administración del Sistema";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = Color.White;
            this.dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Dock = DockStyle.Fill;
            this.dgvDatos.Location = new Point(0, 87);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 29;
            this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new Size(1000, 491);
            this.dgvDatos.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new Size(20, 20);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatus});
            this.statusStrip.Location = new Point(0, 578);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1000, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(54, 17);
            this.lblStatus.Text = "Listo";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.toolStrip);
            this.Name = "AdminForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Panel de Administración";
            this.Load += this.AdminForm_Load;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton btnNuevoUsuario;
        private ToolStripButton btnEditarUsuario;
        private ToolStripButton btnCambiarPassword;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnRefrescar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel lblSeccion;
        private ToolStripComboBox cmbSeccion;
        private Panel panelInfo;
        private Label lblInfo;
        private DataGridView dgvDatos;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
    }
}
