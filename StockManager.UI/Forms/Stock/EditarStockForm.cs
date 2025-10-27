using StockManager.BLL.Services;
using StockManager.DAL.UnitOfWork;

namespace StockManager.UI.Forms.Stock
{
    public partial class EditarStockForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _productoId;
        private int _stockActual;

        public EditarStockForm(IUnitOfWork unitOfWork, int productoId)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _productoId = productoId;
        }

        private async void EditarStockForm_Load(object sender, EventArgs e)
        {
            await CargarProductoAsync();
        }

        private async Task CargarProductoAsync()
        {
            try
            {
                var producto = await _unitOfWork.Productos.GetByIdAsync(_productoId);

                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblProductoNombre.Text = $"{producto.Codigo} - {producto.Nombre}";
                
                _stockActual = producto.Stock?.CantidadActual ?? 0;
                lblStockActual.Text = _stockActual.ToString();
                lblStockMin.Text = (producto.Stock?.CantidadReorden ?? 0).ToString();
                
                numNuevoStock.Value = _stockActual;

                // Color según stock
                if (_stockActual <= (producto.Stock?.CantidadReorden ?? 0))
                {
                    lblStockActual.ForeColor = Color.Red;
                    lblStockActual.Text = $"{_stockActual} (? BAJO)";
                }
                else
                {
                    lblStockActual.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Debe especificar un motivo para el ajuste de stock", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return;
            }

            var nuevoStock = (int)numNuevoStock.Value;
            var diferencia = nuevoStock - _stockActual;

            var confirmacion = MessageBox.Show(
                $"¿Confirmar ajuste de stock?\n\n" +
                $"Stock actual: {_stockActual}\n" +
                $"Nuevo stock: {nuevoStock}\n" +
                $"Diferencia: {(diferencia >= 0 ? "+" : "")}{diferencia}\n\n" +
                $"Motivo: {txtMotivo.Text}",
                "Confirmar Ajuste",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnGuardar.Enabled = false;

                await _unitOfWork.BeginTransactionAsync();

                var producto = await _unitOfWork.Productos.GetByIdAsync(_productoId);

                if (producto?.Stock != null)
                {
                    producto.Stock.CantidadActual = nuevoStock;
                    producto.Stock.FechaModificacion = DateTime.Now;

                    if (nuevoStock > _stockActual)
                    {
                        producto.Stock.FechaUltimoIngreso = DateTime.Now;
                    }
                    else if (nuevoStock < _stockActual)
                    {
                        producto.Stock.FechaUltimaSalida = DateTime.Now;
                    }

                    _unitOfWork.Stocks.Update(producto.Stock);
                    await _unitOfWork.SaveChangesAsync();
                }

                await _unitOfWork.CommitAsync();

                MessageBox.Show(
                    $"Stock actualizado correctamente\n\n" +
                    $"Anterior: {_stockActual}\n" +
                    $"Nuevo: {nuevoStock}\n" +
                    $"Diferencia: {(diferencia >= 0 ? "+" : "")}{diferencia}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                MessageBox.Show($"Error al actualizar stock: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
