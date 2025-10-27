using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.BLL.Services;

namespace StockManager.UI.Forms.Productos
{
    public partial class ProductoEditForm : Form
    {
        private readonly ProductoService _productoService;
        private readonly int? _productoId;
        private ProductoDTO? _productoActual;

        public ProductoEditForm(ProductoService productoService, int? productoId = null)
        {
            InitializeComponent();
            _productoService = productoService;
            _productoId = productoId;
        }

        private async void ProductoEditForm_Load(object sender, EventArgs e)
        {
            await CargarCategoriasAsync();

            if (_productoId.HasValue)
            {
                this.Text = "Editar Producto";
                await CargarProductoAsync(_productoId.Value);
                
                // Deshabilitar stock inicial en edición
                numStockInicial.Enabled = false;
                lblStockInicial.Enabled = false;
            }
            else
            {
                this.Text = "Nuevo Producto";
                numStockInicial.Value = 0;
                numStockMinimo.Value = 10;
            }
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var result = await _productoService.ObtenerCategoriasAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    cmbCategoria.DataSource = result.Data.ToList();
                    cmbCategoria.DisplayMember = "Nombre";
                    cmbCategoria.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("Error al cargar categorías. No se podrá guardar el producto.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductoAsync(int productoId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var result = await _productoService.ObtenerTodosAsync();

                if (result.IsSuccess && result.Data != null)
                {
                    _productoActual = result.Data.FirstOrDefault(p => p.Id == productoId);
                    
                    if (_productoActual != null)
                    {
                        txtCodigo.Text = _productoActual.Codigo;
                        txtNombre.Text = _productoActual.Nombre;
                        txtDescripcion.Text = _productoActual.Descripcion;
                        cmbCategoria.SelectedValue = _productoActual.CategoriaId;
                        numPrecio.Value = _productoActual.PrecioUnitario;
                        numCosto.Value = _productoActual.CostoUnitario;
                        numStockInicial.Value = _productoActual.StockActual;
                        numStockMinimo.Value = _productoActual.StockMinimo;
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
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
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
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

                var productoDto = new ProductoDTO
                {
                    Id = _productoActual?.Id ?? 0,
                    Codigo = txtCodigo.Text.Trim().ToUpper(),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    CategoriaId = (int)cmbCategoria.SelectedValue!,
                    PrecioUnitario = numPrecio.Value,
                    CostoUnitario = numCosto.Value,
                    StockActual = (int)numStockInicial.Value,
                    StockMinimo = (int)numStockMinimo.Value
                };

                Result result;

                if (_productoId.HasValue)
                {
                    result = await _productoService.ActualizarAsync(productoDto);
                }
                else
                {
                    var resultCrear = await _productoService.CrearAsync(productoDto);
                    result = resultCrear.IsSuccess 
                        ? Result.Success(resultCrear.Message) 
                        : Result.Failure(resultCrear.Message);
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
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una categoría", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrecio.Focus();
                return false;
            }

            if (numCosto.Value <= 0)
            {
                MessageBox.Show("El costo debe ser mayor a cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCosto.Focus();
                return false;
            }

            if (numCosto.Value > numPrecio.Value)
            {
                MessageBox.Show("El costo no puede ser mayor al precio de venta", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCosto.Focus();
                return false;
            }

            if (!_productoId.HasValue && numStockInicial.Value < 0)
            {
                MessageBox.Show("El stock inicial no puede ser negativo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numStockInicial.Focus();
                return false;
            }

            if (numStockMinimo.Value < 0)
            {
                MessageBox.Show("El stock mínimo no puede ser negativo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numStockMinimo.Focus();
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
