using StockManager.BLL.Services;
using StockManager.DAL.UnitOfWork;
using StockManager.UI.Extensions;
using System.Text;

namespace StockManager.UI.Forms.Stock
{
    public partial class StockForm : Form
    {
        private readonly ProductoService _productoService;
        private readonly IUnitOfWork _unitOfWork;

        public StockForm(ProductoService productoService, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _productoService = productoService;
            _unitOfWork = unitOfWork;
        }

        private async void StockForm_Load(object sender, EventArgs e)
        {
            await CargarStockAsync();
        }

        private async Task CargarStockAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var result = await _productoService.ObtenerTodosAsync();

                if (result.IsSuccess && result.Data != null)
                {
                    dgvStock.DataSource = result.Data;
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
                MessageBox.Show($"Error al cargar stock: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarGrilla()
        {
            if (dgvStock.Columns.Count == 0) return;

            dgvStock.Columns["Id"]?.SetVisibility(false);
            dgvStock.Columns["CategoriaId"]?.SetVisibility(false);
            dgvStock.Columns["PrecioUnitario"]?.SetVisibility(false);
            dgvStock.Columns["CostoUnitario"]?.SetVisibility(false);
            dgvStock.Columns["Descripcion"]?.SetVisibility(false);

            dgvStock.Columns["Codigo"]?.SetHeader("Código", 100);
            dgvStock.Columns["Nombre"]?.SetHeader("Producto", 300);
            dgvStock.Columns["CategoriaNombre"]?.SetHeader("Categoría", 120);
            dgvStock.Columns["StockActual"]?.SetHeader("Stock Actual", 120);
            dgvStock.Columns["StockMinimo"]?.SetHeader("Stock Mínimo", 120);
            dgvStock.Columns["RequiereReorden"]?.SetHeader("Estado", 100);

            if (dgvStock.Columns["StockActual"] != null)
                dgvStock.Columns["StockActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvStock.Columns["StockMinimo"] != null)
                dgvStock.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStock.Columns[e.ColumnIndex].Name == "RequiereReorden" && e.Value is bool requiere)
            {
                // NO modificar e.Value, solo el estilo
                if (requiere)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.Font = new Font(e.CellStyle.Font!, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.FormattingApplied = true;
                }
            }

            // Resaltar fila completa si requiere reorden
            if (dgvStock.Rows[e.RowIndex].Cells["RequiereReorden"].Value is bool reorden && reorden)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 235, 235);
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarStockAsync();
        }

        private async void btnEditarStock_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar su stock", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoId = Convert.ToInt32(dgvStock.SelectedRows[0].Cells["Id"].Value);
            
            var form = new EditarStockForm(_unitOfWork, productoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarStockAsync();
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
                    dgvStock.DataSource = result.Data;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStock.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = $"Stock_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var csv = new StringBuilder();

                    // Headers
                    var headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvStock.Columns)
                    {
                        if (column.Visible)
                            headers.Add(column.HeaderText);
                    }
                    csv.AppendLine(string.Join(",", headers));

                    // Rows
                    foreach (DataGridViewRow row in dgvStock.Rows)
                    {
                        var values = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.OwningColumn.Visible)
                                values.Add($"\"{cell.Value?.ToString() ?? ""}\"");
                        }
                        csv.AppendLine(string.Join(",", values));
                    }

                    File.WriteAllText(saveDialog.FileName, csv.ToString());

                    MessageBox.Show($"Archivo exportado exitosamente a:\n{saveDialog.FileName}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
