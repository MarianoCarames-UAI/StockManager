using StockManager.BLL.Services;
using StockManager.UI.Extensions;

namespace StockManager.UI.Forms.Productos
{
    public partial class ProductosListForm : Form
    {
        private readonly ProductoService _productoService;
        private int? _categoriaFiltro = null;

        public ProductosListForm(ProductoService productoService)
        {
            InitializeComponent();
            _productoService = productoService;
        }

        private async void ProductosListForm_Load(object sender, EventArgs e)
        {
            await CargarCategoriasAsync();
            await CargarProductosAsync();
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var result = await _productoService.ObtenerCategoriasAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    var categorias = result.Data.ToList();
                    categorias.Insert(0, new BLL.DTOs.CategoriaDTO 
                    { 
                        Id = 0, 
                        Nombre = "-- Todas --" 
                    });

                    cmbCategoria.DataSource = categorias;
                    cmbCategoria.DisplayMember = "Nombre";
                    cmbCategoria.ValueMember = "Id";
                    cmbCategoria.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var result = await _productoService.ObtenerTodosAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    var productos = result.Data;

                    // Filtrar por categoría si está seleccionada
                    if (_categoriaFiltro.HasValue && _categoriaFiltro.Value > 0)
                    {
                        productos = productos.Where(p => p.CategoriaId == _categoriaFiltro.Value).ToList();
                    }

                    dgvProductos.DataSource = productos;
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
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarGrilla()
        {
            if (dgvProductos.Columns.Count == 0) return;

            // Configurar columnas
            dgvProductos.Columns["Id"]?.SetHeader("ID", 60);
            dgvProductos.Columns["Codigo"]?.SetHeader("Código", 100);
            dgvProductos.Columns["Nombre"]?.SetHeader("Nombre", 250);
            dgvProductos.Columns["CategoriaNombre"]?.SetHeader("Categoría", 120);
            dgvProductos.Columns["PrecioUnitario"]?.SetHeader("Precio", 100);
            dgvProductos.Columns["CostoUnitario"]?.SetHeader("Costo", 100);
            dgvProductos.Columns["StockActual"]?.SetHeader("Stock", 80);
            dgvProductos.Columns["StockMinimo"]?.SetHeader("Stock Mín.", 90);
            dgvProductos.Columns["RequiereReorden"]?.SetHeader("¿Reordenar?", 100);

            // Ocultar columnas innecesarias
            dgvProductos.Columns["CategoriaId"]?.SetVisibility(false);
            dgvProductos.Columns["Descripcion"]?.SetVisibility(false);

            // Formato de moneda
            if (dgvProductos.Columns["PrecioUnitario"] != null)
                dgvProductos.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            
            if (dgvProductos.Columns["CostoUnitario"] != null)
                dgvProductos.Columns["CostoUnitario"].DefaultCellStyle.Format = "C2";

            // Alineación
            if (dgvProductos.Columns["StockActual"] != null)
                dgvProductos.Columns["StockActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            if (dgvProductos.Columns["StockMinimo"] != null)
                dgvProductos.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Resaltar productos con stock bajo
            if (dgvProductos.Columns[e.ColumnIndex].Name == "RequiereReorden" && e.Value is bool requiereReorden)
            {
                // NO modificar e.Value, solo el estilo
                if (requiereReorden)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.Font = new Font(e.CellStyle.Font!, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
                else
                {
                    e.FormattingApplied = true;
                }
            }

            // Resaltar fila completa si requiere reorden
            if (dgvProductos.Rows[e.RowIndex].Cells["RequiereReorden"].Value is bool reorden && reorden)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 235, 235);
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var form = new ProductoEditForm(_productoService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarProductosAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await EditarProductoSeleccionadoAsync();
        }

        private async void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await EditarProductoSeleccionadoAsync();
            }
        }

        private async Task EditarProductoSeleccionadoAsync()
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoId = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
            
            var form = new ProductoEditForm(_productoService, productoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarProductosAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoNombre = dgvProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();
            
            var confirmResult = MessageBox.Show(
                $"¿Está seguro que desea eliminar el producto '{productoNombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    
                    var productoId = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
                    var result = await _productoService.EliminarAsync(productoId);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show(result.Message, "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarProductosAsync();
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

        private async void btnStockBajo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var result = await _productoService.ObtenerConStockBajoAsync();
                
                if (result.IsSuccess && result.Data != null)
                {
                    dgvProductos.DataSource = result.Data;
                    ConfigurarGrilla();

                    if (result.Data.Count == 0)
                    {
                        MessageBox.Show("No hay productos con stock bajo", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            _categoriaFiltro = null;
            cmbCategoria.SelectedIndex = 0;
            txtBuscar.Clear();
            await CargarProductosAsync();
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
                await CargarProductosAsync();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                var result = await _productoService.BuscarAsync(txtBuscar.Text.Trim());
                
                if (result.IsSuccess && result.Data != null)
                {
                    dgvProductos.DataSource = result.Data;
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

        private async void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue is int categoriaId)
            {
                _categoriaFiltro = categoriaId > 0 ? categoriaId : null;
                await CargarProductosAsync();
            }
        }
    }
}
