using StockManager.BLL.Services;

namespace StockManager.UI.Forms.Admin
{
    public partial class EmpleadoEditForm : Form
    {
        private readonly EmpleadoService _empleadoService;
        private readonly int? _empleadoId;
        private bool _esNuevo;

        // Constructor para nuevo empleado
        public EmpleadoEditForm(EmpleadoService empleadoService)
        {
            InitializeComponent();
            _empleadoService = empleadoService;
            _empleadoId = null;
            _esNuevo = true;
        }

        // Constructor para editar empleado
        public EmpleadoEditForm(EmpleadoService empleadoService, int empleadoId)
        {
            InitializeComponent();
            _empleadoService = empleadoService;
            _empleadoId = empleadoId;
            _esNuevo = false;
        }

        private async void EmpleadoEditForm_Load(object sender, EventArgs e)
        {
            await CargarRolesAsync();

            if (_esNuevo)
            {
                this.Text = "Nuevo Usuario";
                panelPassword.Visible = true;
            }
            else
            {
                this.Text = "Editar Usuario";
                panelPassword.Visible = false;
                this.ClientSize = new Size(500, 350);
                await CargarDatosEmpleadoAsync();
            }
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                var result = await _empleadoService.ObtenerRolesAsync();

                if (result.IsSuccess && result.Data != null)
                {
                    cmbRol.DataSource = result.Data;
                    cmbRol.DisplayMember = "Nombre";
                    cmbRol.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosEmpleadoAsync()
        {
            if (!_empleadoId.HasValue) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var result = await _empleadoService.ObtenerPorIdAsync(_empleadoId.Value);

                if (result.IsSuccess && result.Data != null)
                {
                    var empleado = result.Data;
                    txtNombre.Text = empleado.Nombre;
                    txtApellido.Text = empleado.Apellido;
                    txtEmail.Text = empleado.Email;
                    cmbRol.SelectedValue = empleado.RolId;
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnGuardar.Enabled = false;

                if (_esNuevo)
                {
                    await CrearEmpleadoAsync();
                }
                else
                {
                    await ActualizarEmpleadoAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }

        private async Task CrearEmpleadoAsync()
        {
            var result = await _empleadoService.CrearAsync(
                txtNombre.Text,
                txtApellido.Text,
                txtEmail.Text,
                (int)cmbRol.SelectedValue!,
                txtPassword.Text
            );

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarEmpleadoAsync()
        {
            var result = await _empleadoService.ActualizarAsync(
                _empleadoId!.Value,
                txtNombre.Text,
                txtApellido.Text,
                txtEmail.Text,
                (int)cmbRol.SelectedValue!
            );

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El email es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("El formato del email es inválido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            if (_esNuevo)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("La contraseña es requerida", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtConfirmarPassword.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmarPassword.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}