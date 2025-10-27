using StockManager.BLL.Services;
using StockManager.UI.Extensions;
using StockManager.UI.Forms.Clientes;

namespace StockManager.UI.Forms.Ventas
{
    public partial class VentasListForm : Form
    {
        private readonly VentaService _ventaService;
        private readonly ClienteService _clienteService;

        public VentasListForm(VentaService ventaService, ClienteService clienteService)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _clienteService = clienteService;
        }

        private async void VentasListForm_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            await CargarVentasDelDiaAsync();
        }

        private async Task CargarVentasDelDiaAsync()
        {
            await CargarVentasAsync(DateTime.Today, DateTime.Today.AddDays(1));
        }

        private async Task CargarVentasAsync(DateTime desde, DateTime hasta)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var result = await _ventaService.ObtenerPorFechaAsync(desde, hasta);
                
                if (result.IsSuccess && result.Data != null)
                {
                    dgvVentas.DataSource = result.Data;
                    ConfigurarGrilla();
                    
                    var total = result.Data.Sum(v => v.Total);
                    lblTotalVentas.Text = $"Total: {total:C2} ({result.Data.Count} ventas)";
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarGrilla()
        {
            if (dgvVentas.Columns.Count == 0) return;

            dgvVentas.Columns["Id"]?.SetHeader("ID", 60);
            dgvVentas.Columns["Fecha"]?.SetHeader("Fecha", 120);
            dgvVentas.Columns["NumeroComprobante"]?.SetHeader("Comprobante", 150);
            dgvVentas.Columns["ClienteNombre"]?.SetHeader("Cliente", 200);
            dgvVentas.Columns["EmpleadoNombre"]?.SetHeader("Vendedor", 150);
            dgvVentas.Columns["Total"]?.SetHeader("Total", 120);
            dgvVentas.Columns["Observaciones"]?.SetHeader("Observaciones", 200);

            dgvVentas.Columns["ClienteId"]?.SetVisibility(false);
            dgvVentas.Columns["EmpleadoId"]?.SetVisibility(false);
            dgvVentas.Columns["Detalles"]?.SetVisibility(false);

            if (dgvVentas.Columns["Total"] != null)
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";

            if (dgvVentas.Columns["Fecha"] != null)
                dgvVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private async void btnNueva_Click(object sender, EventArgs e)
        {
            var form = new NuevaVentaForm(_ventaService, _clienteService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarVentasDelDiaAsync();
            }
        }

        private async void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            await CargarVentasDelDiaAsync();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarVentasAsync(dtpDesde.Value.Date, dtpHasta.Value.Date.AddDays(1));
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await CargarVentasAsync(dtpDesde.Value.Date, dtpHasta.Value.Date.AddDays(1));
        }
    }
}
