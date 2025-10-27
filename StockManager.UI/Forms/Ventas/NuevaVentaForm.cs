using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.BLL.Services;
using StockManager.BLL.Session;
using StockManager.UI.Extensions;
using System.ComponentModel;

namespace StockManager.UI.Forms.Ventas
{
    public partial class NuevaVentaForm : Form
    {
        private readonly VentaService _ventaService;
        private readonly ClienteService _clienteService;
        private BindingList<DetalleVentaDTO> _carrito;
        private List<DetalleVentaDTO> _productosDisponibles = new();

        public NuevaVentaForm(VentaService ventaService, ClienteService clienteService)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _clienteService = clienteService;
            _carrito = new BindingList<DetalleVentaDTO>();
        }

        private async void NuevaVentaForm_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            await CargarClientesAsync();
            await CargarProductosAsync();
            ConfigurarGrilla();
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                var result = await _clienteService.ObtenerTodosAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    cmbCliente.DataSource = result.Data;
                    cmbCliente.DisplayMember = "NombreCompleto";
                    cmbCliente.ValueMember = "Id";
                    cmbCliente.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var result = await _ventaService.ObtenerProductosDisponiblesAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    _productosDisponibles = result.Data;
                    
                    cmbProducto.DataSource = _productosDisponibles;
                    cmbProducto.DisplayMember = "ProductoNombre";
                    cmbProducto.ValueMember = "ProductoId";
                    cmbProducto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            dgvCarrito.DataSource = _carrito;

            if (dgvCarrito.Columns.Count > 0)
            {
                dgvCarrito.Columns["Id"]?.SetVisibility(false);
                dgvCarrito.Columns["VentaId"]?.SetVisibility(false);
                dgvCarrito.Columns["ProductoId"]?.SetVisibility(false);
                dgvCarrito.Columns["StockDisponible"]?.SetVisibility(false);

                dgvCarrito.Columns["ProductoCodigo"]?.SetHeader("Código", 100);
                dgvCarrito.Columns["ProductoNombre"]?.SetHeader("Producto", 300);
                dgvCarrito.Columns["Cantidad"]?.SetHeader("Cantidad", 100);
                dgvCarrito.Columns["PrecioUnitario"]?.SetHeader("Precio Unit.", 120);
                dgvCarrito.Columns["Subtotal"]?.SetHeader("Subtotal", 120);

                if (dgvCarrito.Columns["PrecioUnitario"] != null)
                    dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";

                if (dgvCarrito.Columns["Subtotal"] != null)
                    dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is DetalleVentaDTO producto)
            {
                lblStockDisponible.Text = $"Stock: {producto.StockDisponible} unid.";
                lblStockDisponible.ForeColor = producto.StockDisponible > 0 ? Color.Green : Color.Red;
                
                numCantidad.Maximum = producto.StockDisponible > 0 ? producto.StockDisponible : 0;
                numCantidad.Value = producto.StockDisponible > 0 ? 1 : 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (DetalleVentaDTO)cmbProducto.SelectedItem;

            // Verificar si ya está en el carrito
            var existente = _carrito.FirstOrDefault(x => x.ProductoId == productoSeleccionado.ProductoId);
            
            if (existente != null)
            {
                // Actualizar cantidad
                var nuevaCantidad = existente.Cantidad + (int)numCantidad.Value;
                
                if (nuevaCantidad > productoSeleccionado.StockDisponible)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {productoSeleccionado.StockDisponible}",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                existente.Cantidad = nuevaCantidad;
                _carrito.ResetBindings();
            }
            else
            {
                // Agregar nuevo
                var detalle = new DetalleVentaDTO
                {
                    ProductoId = productoSeleccionado.ProductoId,
                    ProductoCodigo = productoSeleccionado.ProductoCodigo,
                    ProductoNombre = productoSeleccionado.ProductoNombre,
                    Cantidad = (int)numCantidad.Value,
                    PrecioUnitario = productoSeleccionado.PrecioUnitario,
                    StockDisponible = productoSeleccionado.StockDisponible
                };

                _carrito.Add(detalle);
            }

            ActualizarTotal();
            
            // Resetear selección
            cmbProducto.SelectedIndex = -1;
            numCantidad.Value = 1;
            lblStockDisponible.Text = "Stock: 0 unid.";
        }

        private void dgvCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvCarrito.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("¿Eliminar el producto seleccionado del carrito?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var index = dgvCarrito.SelectedRows[0].Index;
                    _carrito.RemoveAt(index);
                    ActualizarTotal();
                }
            }
        }

        private void ActualizarTotal()
        {
            var total = _carrito.Sum(x => x.Subtotal);
            lblTotalValor.Text = total.ToString("C2");
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarVenta())
                return;

            var confirmResult = MessageBox.Show(
                $"¿Confirmar venta por {lblTotalValor.Text}?",
                "Confirmar Venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnConfirmar.Enabled = false;

                var ventaDto = new VentaDTO
                {
                    ClienteId = (int)cmbCliente.SelectedValue!,
                    EmpleadoId = SessionManager.Instance.CurrentUser!.Id,
                    Observaciones = txtObservaciones.Text.Trim(),
                    Detalles = _carrito.ToList()
                };

                var result = await _ventaService.CrearVentaAsync(ventaDto);

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
                MessageBox.Show($"Error al confirmar venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnConfirmar.Enabled = true;
            }
        }

        private bool ValidarVenta()
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return false;
            }

            if (_carrito.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProducto.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_carrito.Count > 0)
            {
                var result = MessageBox.Show(
                    "¿Cancelar la venta? Se perderán los datos ingresados.",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
