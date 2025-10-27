using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.BLL.Services;
using StockManager.Domain.Enums;

namespace StockManager.UI.Forms.Clientes
{
    public partial class ClienteEditForm : Form
    {
        private readonly ClienteService _clienteService;
        private readonly int? _clienteId;
        private ClienteDTO? _clienteActual;

        public ClienteEditForm(ClienteService clienteService, int? clienteId = null)
        {
            InitializeComponent();
            _clienteService = clienteService;
            _clienteId = clienteId;
        }

        private async void ClienteEditForm_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (_clienteId.HasValue)
            {
                this.Text = "Editar Cliente";
                await CargarClienteAsync(_clienteId.Value);
            }
            else
            {
                this.Text = "Nuevo Cliente";
                // Valores por defecto
                cmbTipoDocumento.SelectedValue = (int)TipoDocumento.DNI;
                cmbEstado.SelectedValue = (int)EstadoCliente.Activo;
            }
        }

        private void CargarCombos()
        {
            // Tipo de Documento
            var tiposDocumento = Enum.GetValues(typeof(TipoDocumento))
                .Cast<TipoDocumento>()
                .Select(t => new { Value = (int)t, Text = t.ToString() })
                .ToList();

            cmbTipoDocumento.DataSource = tiposDocumento;
            cmbTipoDocumento.DisplayMember = "Text";
            cmbTipoDocumento.ValueMember = "Value";

            // Estado
            var estados = Enum.GetValues(typeof(EstadoCliente))
                .Cast<EstadoCliente>()
                .Select(e => new { Value = (int)e, Text = e.ToString() })
                .ToList();

            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
        }

        private async Task CargarClienteAsync(int clienteId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var result = await _clienteService.ObtenerPorIdAsync(clienteId);

                if (result.IsSuccess && result.Data != null)
                {
                    _clienteActual = result.Data;
                    
                    txtNombre.Text = _clienteActual.Nombre;
                    txtApellido.Text = _clienteActual.Apellido;
                    cmbTipoDocumento.SelectedValue = _clienteActual.TipoDocumento;
                    txtDocumento.Text = _clienteActual.Documento;
                    txtDireccion.Text = _clienteActual.Direccion;
                    txtTelefono.Text = _clienteActual.Telefono;
                    txtEmail.Text = _clienteActual.Email;
                    cmbEstado.SelectedValue = _clienteActual.Estado;
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
                MessageBox.Show($"Error al cargar cliente: {ex.Message}", "Error",
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

                var clienteDto = new ClienteDTO
                {
                    Id = _clienteActual?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    TipoDocumento = (int)cmbTipoDocumento.SelectedValue!,
                    Documento = txtDocumento.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Estado = (int)cmbEstado.SelectedValue!
                };

                Result result;

                if (_clienteId.HasValue)
                {
                    result = await _clienteService.ActualizarAsync(clienteDto);
                }
                else
                {
                    var resultCrear = await _clienteService.CrearAsync(clienteDto);
                    result = Result.Success(resultCrear.Message);
                    if (!resultCrear.IsSuccess)
                        result = Result.Failure(resultCrear.Message);
                }

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
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
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

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El documento es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("El email no tiene un formato válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
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
