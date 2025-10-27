namespace StockManager.Domain.Entities;

/// <summary>
/// Representa una venta realizada en el sistema
/// </summary>
public class Venta : BaseEntity
{
    /// <summary>
    /// Fecha de la venta
    /// </summary>
    public DateTime Fecha { get; set; } = DateTime.Now;
    
    /// <summary>
    /// ID del cliente
    /// </summary>
    public int ClienteId { get; set; }
    
    /// <summary>
    /// Cliente que realizó la compra
    /// </summary>
    public virtual Cliente Cliente { get; set; } = null!;
    
    /// <summary>
    /// ID del empleado/vendedor
    /// </summary>
    public int EmpleadoId { get; set; }
    
    /// <summary>
    /// Empleado que realizó la venta
    /// </summary>
    public virtual Empleado Empleado { get; set; } = null!;
    
    /// <summary>
    /// Total de la venta
    /// </summary>
    public decimal Total { get; set; }
    
    /// <summary>
    /// Número de comprobante
    /// </summary>
    public string? NumeroComprobante { get; set; }
    
    /// <summary>
    /// Observaciones adicionales
    /// </summary>
    public string? Observaciones { get; set; }
    
    /// <summary>
    /// Detalles de los productos vendidos
    /// </summary>
    public virtual ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
}
