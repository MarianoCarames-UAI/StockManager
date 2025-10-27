namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para DetalleVenta
/// </summary>
public class DetalleVentaDTO
{
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public string ProductoCodigo { get; set; } = string.Empty;
    public string ProductoNombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;
    public int StockDisponible { get; set; }
}
