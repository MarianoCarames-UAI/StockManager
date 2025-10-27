using StockManager.BLL.Services;

namespace StockManager.UI.Forms.Admin
{
    public partial class CambiarPasswordForm : Form
    {
        private readonly EmpleadoService _empleadoService;
        private readonly int _empleadoId;
        private string _nombreEmpleado = string.Empty;
        private string _emailEmpleado = string.Empty;

        public CambiarPasswordForm(EmpleadoService empleadoService, int empleadoId)
        {
            InitializeComponent();
            _empleadoService = empleadoService;
            _empleadoId = empleadoId;
        }

        private async void CambiarPasswordForm_Load(object sender, EventArgs e)
        {
            await CargarDatosEmpleadoAsync();
        }

        private async Task CargarDatosEmpleadoAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var result = await _empleadoService.ObtenerPorIdAsync(_empleadoId);

                if (result.IsSuccess && result.Data != null)
                {
                    var empleado = result.Data;
                    _nombreEmpleado = empleado.NombreCompleto;
                    _emailEmpleado = empleado.Email;
                    lblUsuarioInfo.Text = $"{empleado.NombreCompleto} ({empleado.Email})";
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

                var result = await _empleadoService.CambiarPasswordAsync(_empleadoId, txtNuevoPassword.Text);

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

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNuevoPassword.Text))
            {
                MessageBox.Show("La contraseña es requerida", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevoPassword.Focus();
                return false;
            }

            if (txtNuevoPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevoPassword.Focus();
                return false;
            }

            if (txtNuevoPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarPassword.Focus();
                return false;
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
