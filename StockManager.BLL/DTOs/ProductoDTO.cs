namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para Producto
/// </summary>
public class ProductoDTO
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int CategoriaId { get; set; }
    public string CategoriaNombre { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public decimal CostoUnitario { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public bool RequiereReorden => StockActual <= StockMinimo;
}
