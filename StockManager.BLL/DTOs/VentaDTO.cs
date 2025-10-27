namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para Venta
/// </summary>
public class VentaDTO
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public int EmpleadoId { get; set; }
    public string EmpleadoNombre { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string? NumeroComprobante { get; set; }
    public string? Observaciones { get; set; }
    public List<DetalleVentaDTO> Detalles { get; set; } = new();
}
