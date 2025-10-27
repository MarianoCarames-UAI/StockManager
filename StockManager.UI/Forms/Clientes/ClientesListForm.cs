using StockManager.BLL.Services;
using StockManager.Services.Localization;
using StockManager.UI.Extensions;

namespace StockManager.UI.Forms.Clientes
{
    public partial class ClientesListForm : Form
    {
        private readonly ClienteService _clienteService;
        private readonly LocalizationService _localization;

        public ClientesListForm(ClienteService clienteService)
        {
            InitializeComponent();
            _clienteService = clienteService;
            _localization = LocalizationService.Instance;
            
            _localization.OnLanguageChanged += (s, lang) => AplicarTraducciones();
        }

        private async void ClientesListForm_Load(object sender, EventArgs e)
        {
            AplicarTraducciones();
            await CargarClientesAsync();
        }

        private void AplicarTraducciones()
        {
            this.Text = _localization.GetString("Clients_Title");
            
            btnNuevo.Text = _localization.GetString("Common_New");
            btnEditar.Text = _localization.GetString("Common_Edit");
            btnEliminar.Text = _localization.GetString("Common_Delete");
            btnRefrescar.Text = _localization.GetString("Common_Search");
            lblBuscar.Text = _localization.GetString("Clients_Search");
            btnBuscar.Text = _localization.GetString("Common_Search");
            
            ConfigurarGrilla();
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var result = await _clienteService.ObtenerTodosAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    dgvClientes.DataSource = result.Data;
                    ConfigurarGrilla();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarGrilla()
        {
            if (dgvClientes.Columns.Count == 0) return;

            // Ocultar columnas innecesarias
            dgvClientes.Columns["TipoDocumento"]?.SetVisibility(false);
            dgvClientes.Columns["Estado"]?.SetVisibility(false);

            // Configurar columnas visibles
            dgvClientes.Columns["Id"]?.SetHeader("ID", 60);
            dgvClientes.Columns["NombreCompleto"]?.SetHeader(_localization.GetString("Clients_Name"), 200);
            dgvClientes.Columns["TipoDocumentoNombre"]?.SetHeader("Tipo Doc.", 100);
            dgvClientes.Columns["Documento"]?.SetHeader(_localization.GetString("Clients_Document"), 120);
            dgvClientes.Columns["Telefono"]?.SetHeader(_localization.GetString("Clients_Phone"), 120);
            dgvClientes.Columns["Email"]?.SetHeader(_localization.GetString("Clients_Email"), 180);
            dgvClientes.Columns["EstadoNombre"]?.SetHeader("Estado", 100);
            dgvClientes.Columns["FechaAlta"]?.SetHeader("Fecha Alta", 120);

            // Ocultar campos individuales si existe NombreCompleto
            dgvClientes.Columns["Nombre"]?.SetVisibility(false);
            dgvClientes.Columns["Apellido"]?.SetVisibility(false);
            dgvClientes.Columns["Direccion"]?.SetVisibility(false);
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var form = new ClienteEditForm(_clienteService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarClientesAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await EditarClienteSeleccionadoAsync();
        }

        private async void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await EditarClienteSeleccionadoAsync();
            }
        }

        private async Task EditarClienteSeleccionadoAsync()
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
            
            var form = new ClienteEditForm(_clienteService, clienteId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarClientesAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clienteNombre = dgvClientes.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();
            
            var confirmResult = MessageBox.Show(
                $"¿Está seguro que desea eliminar al cliente '{clienteNombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    
                    var clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
                    var result = await _clienteService.EliminarAsync(clienteId);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarClientesAsync();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await BuscarAsync();
            }
        }

        private async Task BuscarAsync()
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                await CargarClientesAsync();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var result = await _clienteService.BuscarAsync(txtBuscar.Text.Trim());
                
                if (result.IsSuccess && result.Data != null)
                {
                    dgvClientes.DataSource = result.Data;
                    ConfigurarGrilla();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
