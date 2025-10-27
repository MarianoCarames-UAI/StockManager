using StockManager.BLL.Services;
using StockManager.DAL.UnitOfWork;
using StockManager.Services.Localization;

namespace StockManager.UI.Forms.Admin
{
    public partial class AdminForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmpleadoService _empleadoService;
        private readonly LocalizationService _localization;
        private string _seccionActual = "Usuarios";

        public AdminForm(IUnitOfWork unitOfWork, EmpleadoService empleadoService)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _empleadoService = empleadoService;
            _localization = LocalizationService.Instance;
            
            _localization.OnLanguageChanged += (s, lang) => AplicarTraducciones();
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                CargarSecciones();
                AplicarTraducciones();
                await CargarDatosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{_localization.GetString("Msg_LoadError")}:\n\n{ex.Message}",
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void CargarSecciones()
        {
            cmbSeccion.Items.Clear();
            cmbSeccion.Items.Add("Usuarios");
            cmbSeccion.Items.Add("Roles");
            cmbSeccion.Items.Add("Sistema");
            cmbSeccion.SelectedIndex = 0;
        }

        private void AplicarTraducciones()
        {
            this.Text = _localization.GetString("Admin_Title");
            
            btnNuevoUsuario.Text = _localization.GetString("Admin_NewUser");
            btnEditarUsuario.Text = _localization.GetString("Admin_EditUser");
            btnCambiarPassword.Text = _localization.GetString("Admin_ChangePassword");
            btnRefrescar.Text = _localization.GetString("Common_Search");
            lblSeccion.Text = _localization.GetString("Admin_System") + ":";
            lblStatus.Text = _localization.GetString("Common_OK");
            
            ActualizarInfoSegunSeccion();
        }

        private void ActualizarInfoSegunSeccion()
        {
            switch (_seccionActual)
            {
                case "Usuarios":
                    lblInfo.Text = _localization.GetString("Admin_Users");
                    btnNuevoUsuario.Visible = true;
                    btnEditarUsuario.Visible = true;
                    btnCambiarPassword.Visible = true;
                    break;
                case "Roles":
                    lblInfo.Text = _localization.GetString("Admin_Roles");
                    btnNuevoUsuario.Visible = false;
                    btnEditarUsuario.Visible = false;
                    btnCambiarPassword.Visible = false;
                    break;
                case "Sistema":
                    lblInfo.Text = "Información del Sistema";
                    btnNuevoUsuario.Visible = false;
                    btnEditarUsuario.Visible = false;
                    btnCambiarPassword.Visible = false;
                    break;
            }
        }

        private async void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeccion.SelectedItem != null)
            {
                _seccionActual = cmbSeccion.SelectedItem.ToString() ?? "Usuarios";
                ActualizarInfoSegunSeccion();
                await CargarDatosAsync();
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Cargando...";

                switch (_seccionActual)
                {
                    case "Usuarios":
                        await CargarUsuariosAsync();
                        break;
                    case "Roles":
                        await CargarRolesAsync();
                        break;
                    case "Sistema":
                        CargarInformacionSistema();
                        break;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarUsuariosAsync()
        {
            try
            {
                if (_unitOfWork?.Empleados == null)
                {
                    MessageBox.Show(
                        "El servicio de empleados no está disponible", 
                        _localization.GetString("Common_Warning"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var empleados = await _unitOfWork.Empleados.GetAllActiveAsync();
                
                if (empleados == null || !empleados.Any())
                {
                    dgvDatos.DataSource = new List<object>();
                    lblStatus.Text = "No hay usuarios registrados";
                    return;
                }

                dgvDatos.DataSource = empleados.Select(e => new
                {
                    e.Id,
                    NombreCompleto = e.NombreCompleto,
                    e.Email,
                    Rol = e.Rol?.Nombre ?? "Sin rol",
                    FechaCreacion = e.FechaCreacion
                }).ToList();

                ConfigurarGrillaUsuarios();
                lblStatus.Text = $"{empleados.Count()} usuarios registrados";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_localization.GetString("Msg_LoadError")}: {ex.Message}", 
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = _localization.GetString("Msg_LoadError");
            }
        }

        private void ConfigurarGrillaUsuarios()
        {
            if (dgvDatos.Columns.Count == 0) return;

            if (dgvDatos.Columns["Id"] != null)
            {
                dgvDatos.Columns["Id"].HeaderText = "ID";
                dgvDatos.Columns["Id"].Width = 60;
            }

            if (dgvDatos.Columns["NombreCompleto"] != null)
            {
                dgvDatos.Columns["NombreCompleto"].HeaderText = _localization.GetString("Clients_Name");
                dgvDatos.Columns["NombreCompleto"].Width = 200;
            }

            if (dgvDatos.Columns["Email"] != null)
            {
                dgvDatos.Columns["Email"].HeaderText = _localization.GetString("Admin_Email");
                dgvDatos.Columns["Email"].Width = 250;
            }

            if (dgvDatos.Columns["Rol"] != null)
            {
                dgvDatos.Columns["Rol"].HeaderText = _localization.GetString("Admin_Role");
                dgvDatos.Columns["Rol"].Width = 150;
            }

            if (dgvDatos.Columns["FechaCreacion"] != null)
            {
                dgvDatos.Columns["FechaCreacion"].HeaderText = _localization.GetString("Admin_CreatedDate");
                dgvDatos.Columns["FechaCreacion"].Width = 150;
                dgvDatos.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var form = new EmpleadoEditForm(_empleadoService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarUsuariosAsync();
            }
        }

        private async void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    _localization.GetString("Msg_NoSelection"), 
                    _localization.GetString("Common_Warning"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userId = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["Id"].Value);
            
            var form = new EmpleadoEditForm(_empleadoService, userId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuariosAsync();
            }
        }

        private async void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    _localization.GetString("Msg_NoSelection"), 
                    _localization.GetString("Common_Warning"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userId = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["Id"].Value);
            
            var form = new CambiarPasswordForm(_empleadoService, userId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    _localization.GetString("Msg_SaveSuccess"), 
                    _localization.GetString("Common_Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                if (_unitOfWork?.Roles == null)
                {
                    lblStatus.Text = "Servicio de roles no disponible";
                    return;
                }

                var roles = await _unitOfWork.Roles.GetAllActiveAsync();
                
                if (roles == null || !roles.Any())
                {
                    dgvDatos.DataSource = new List<object>();
                    lblStatus.Text = "No hay roles registrados";
                    return;
                }

                dgvDatos.DataSource = roles.Select(r => new
                {
                    r.Id,
                    r.Nombre,
                    r.Descripcion,
                    CantidadUsuarios = r.Empleados?.Count ?? 0
                }).ToList();

                ConfigurarGrillaRoles();
                lblStatus.Text = $"{roles.Count()} roles del sistema";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_localization.GetString("Msg_LoadError")}: {ex.Message}", 
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = _localization.GetString("Msg_LoadError");
            }
        }

        private void ConfigurarGrillaRoles()
        {
            if (dgvDatos.Columns.Count == 0) return;

            if (dgvDatos.Columns["Id"] != null)
            {
                dgvDatos.Columns["Id"].HeaderText = "ID";
                dgvDatos.Columns["Id"].Width = 60;
            }

            if (dgvDatos.Columns["Nombre"] != null)
            {
                dgvDatos.Columns["Nombre"].HeaderText = _localization.GetString("Admin_Role");
                dgvDatos.Columns["Nombre"].Width = 200;
            }

            if (dgvDatos.Columns["Descripcion"] != null)
            {
                dgvDatos.Columns["Descripcion"].HeaderText = _localization.GetString("Products_Description");
                dgvDatos.Columns["Descripcion"].Width = 400;
            }

            if (dgvDatos.Columns["CantidadUsuarios"] != null)
            {
                dgvDatos.Columns["CantidadUsuarios"].HeaderText = _localization.GetString("Admin_Users");
                dgvDatos.Columns["CantidadUsuarios"].Width = 100;
            }
        }

        private void CargarInformacionSistema()
        {
            var info = new List<object>
            {
                new { Propiedad = "Base de Datos", Valor = "StockManagerDB" },
                new { Propiedad = "Versión", Valor = "StockManager v2.0.100" },
                new { Propiedad = "Framework", Valor = ".NET 8.0" },
                new { Propiedad = "ORM", Valor = "Entity Framework Core" }
            };

            dgvDatos.DataSource = info;
            
            if (dgvDatos.Columns.Count > 0)
            {
                if (dgvDatos.Columns["Propiedad"] != null)
                {
                    dgvDatos.Columns["Propiedad"].HeaderText = "Propiedad";
                    dgvDatos.Columns["Propiedad"].Width = 300;
                }

                if (dgvDatos.Columns["Valor"] != null)
                {
                    dgvDatos.Columns["Valor"].HeaderText = "Valor";
                    dgvDatos.Columns["Valor"].Width = 500;
                }
            }

            lblStatus.Text = "Información del sistema";
        }
    }
}
