using StockManager.BLL.Services;
using StockManager.Services.Localization;
using StockManager.UI.Extensions;

namespace StockManager.UI.Forms.Reportes
{
    public partial class ReportesForm : Form
    {
        private readonly VentaService _ventaService;
        private readonly ProductoService _productoService;
        private readonly ClienteService _clienteService;
        private readonly LocalizationService _localization;
        private string _tipoReporteActual = "Ventas";

        public ReportesForm(VentaService ventaService, ProductoService productoService, ClienteService clienteService)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _productoService = productoService;
            _clienteService = clienteService;
            _localization = LocalizationService.Instance;
            
            _localization.OnLanguageChanged += (s, lang) => AplicarTraducciones();
        }

        private async void ReportesForm_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            
            CargarTiposReporte();
            AplicarTraducciones();
            
            await CargarDatosAsync();
        }

        private void CargarTiposReporte()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Ventas");
            cmbTipoReporte.Items.Add("Productos");
            cmbTipoReporte.Items.Add("Clientes");
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void AplicarTraducciones()
        {
            this.Text = _localization.GetString("Reports_Title");
            
            btnRefrescar.Text = _localization.GetString("Common_Search");
            lblTipoReporte.Text = _localization.GetString("Reports_Title") + ":";
            lblDesde.Text = _localization.GetString("Reports_From") + ":";
            lblHasta.Text = _localization.GetString("Reports_To") + ":";
            btnBuscar.Text = _localization.GetString("Reports_Search");
            lblStatus.Text = _localization.GetString("Common_OK");
        }

        private async void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedItem != null)
            {
                _tipoReporteActual = cmbTipoReporte.SelectedItem.ToString() ?? "Ventas";
                await CargarDatosAsync();
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblStatus.Text = $"{_localization.GetString("Reports_Search")}...";

                switch (_tipoReporteActual)
                {
                    case "Ventas":
                        await CargarVentasAsync();
                        break;
                    case "Productos":
                        await CargarProductosAsync();
                        break;
                    case "Clientes":
                        await CargarClientesAsync();
                        break;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarVentasAsync()
        {
            try
            {
                var result = await _ventaService.ObtenerPorFechaAsync(
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date.AddDays(1));

                if (result.IsSuccess && result.Data != null)
                {
                    dgvReportes.DataSource = result.Data;
                    ConfigurarGrillaVentas();

                    var total = result.Data.Sum(v => v.Total);
                    lblStatus.Text = $"{_localization.GetString("Sales_Total")}: {total:C2} - {result.Data.Count} registros";
                }
                else
                {
                    dgvReportes.DataSource = null;
                    lblStatus.Text = result.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_localization.GetString("Msg_LoadError")}: {ex.Message}", 
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = _localization.GetString("Msg_LoadError");
            }
        }

        private void ConfigurarGrillaVentas()
        {
            if (dgvReportes.Columns.Count == 0) return;

            dgvReportes.Columns["Id"]?.SetVisibility(false);
            dgvReportes.Columns["ClienteId"]?.SetVisibility(false);
            dgvReportes.Columns["EmpleadoId"]?.SetVisibility(false);
            dgvReportes.Columns["Detalles"]?.SetVisibility(false);

            dgvReportes.Columns["Fecha"]?.SetHeader(_localization.GetString("Sales_Date"), 150);
            dgvReportes.Columns["NumeroComprobante"]?.SetHeader("N° Comprobante", 150);
            dgvReportes.Columns["ClienteNombre"]?.SetHeader(_localization.GetString("Sales_Client"), 200);
            dgvReportes.Columns["EmpleadoNombre"]?.SetHeader(_localization.GetString("Admin_User"), 150);
            dgvReportes.Columns["Total"]?.SetHeader(_localization.GetString("Sales_Total"), 120);

            if (dgvReportes.Columns["Total"] != null)
                dgvReportes.Columns["Total"].DefaultCellStyle.Format = "C2";

            if (dgvReportes.Columns["Fecha"] != null)
                dgvReportes.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var result = await _productoService.ObtenerTodosAsync();

                if (result.IsSuccess && result.Data != null)
                {
                    dgvReportes.DataSource = result.Data;
                    ConfigurarGrillaProductos();
                    lblStatus.Text = $"{_localization.GetString("Products_Title")}: {result.Data.Count} registros";
                }
                else
                {
                    dgvReportes.DataSource = null;
                    lblStatus.Text = result.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_localization.GetString("Msg_LoadError")}: {ex.Message}", 
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = _localization.GetString("Msg_LoadError");
            }
        }

        private void ConfigurarGrillaProductos()
        {
            if (dgvReportes.Columns.Count == 0) return;

            dgvReportes.Columns["Id"]?.SetVisibility(false);
            dgvReportes.Columns["CategoriaId"]?.SetVisibility(false);
            dgvReportes.Columns["CostoUnitario"]?.SetVisibility(false);
            dgvReportes.Columns["Descripcion"]?.SetVisibility(false);
            dgvReportes.Columns["RequiereReorden"]?.SetVisibility(false);

            dgvReportes.Columns["Codigo"]?.SetHeader(_localization.GetString("Products_Code"), 100);
            dgvReportes.Columns["Nombre"]?.SetHeader(_localization.GetString("Products_Name"), 250);
            dgvReportes.Columns["CategoriaNombre"]?.SetHeader(_localization.GetString("Products_Category"), 120);
            dgvReportes.Columns["PrecioUnitario"]?.SetHeader(_localization.GetString("Products_Price"), 100);
            dgvReportes.Columns["StockActual"]?.SetHeader(_localization.GetString("Products_Stock"), 80);
            dgvReportes.Columns["StockMinimo"]?.SetHeader(_localization.GetString("Products_MinStock"), 90);

            if (dgvReportes.Columns["PrecioUnitario"] != null)
                dgvReportes.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                var result = await _clienteService.ObtenerTodosAsync();

                if (result.IsSuccess && result.Data != null)
                {
                    dgvReportes.DataSource = result.Data;
                    ConfigurarGrillaClientes();
                    lblStatus.Text = $"{_localization.GetString("Clients_Title")}: {result.Data.Count} registros";
                }
                else
                {
                    dgvReportes.DataSource = null;
                    lblStatus.Text = result.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_localization.GetString("Msg_LoadError")}: {ex.Message}", 
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = _localization.GetString("Msg_LoadError");
            }
        }

        private void ConfigurarGrillaClientes()
        {
            if (dgvReportes.Columns.Count == 0) return;

            dgvReportes.Columns["Id"]?.SetVisibility(false);
            dgvReportes.Columns["TipoDocumento"]?.SetVisibility(false);
            dgvReportes.Columns["Estado"]?.SetVisibility(false);
            dgvReportes.Columns["Nombre"]?.SetVisibility(false);
            dgvReportes.Columns["Apellido"]?.SetVisibility(false);
            dgvReportes.Columns["Direccion"]?.SetVisibility(false);

            dgvReportes.Columns["NombreCompleto"]?.SetHeader(_localization.GetString("Clients_Name"), 250);
            dgvReportes.Columns["TipoDocumentoNombre"]?.SetHeader("Tipo Doc.", 100);
            dgvReportes.Columns["Documento"]?.SetHeader(_localization.GetString("Clients_Document"), 120);
            dgvReportes.Columns["Telefono"]?.SetHeader(_localization.GetString("Clients_Phone"), 120);
            dgvReportes.Columns["Email"]?.SetHeader(_localization.GetString("Clients_Email"), 200);
            dgvReportes.Columns["EstadoNombre"]?.SetHeader("Estado", 100);
            dgvReportes.Columns["FechaAlta"]?.SetHeader(_localization.GetString("Admin_CreatedDate"), 120);

            if (dgvReportes.Columns["FechaAlta"] != null)
                dgvReportes.Columns["FechaAlta"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
}
