namespace StockManager.Domain.Entities;

/// <summary>
/// Representa el detalle de una venta (productos vendidos)
/// </summary>
public class DetalleVenta : BaseEntity
{
    /// <summary>
    /// ID de la venta
    /// </summary>
    public int VentaId { get; set; }
    
    /// <summary>
    /// Venta asociada
    /// </summary>
    public virtual Venta Venta { get; set; } = null!;
    
    /// <summary>
    /// ID del producto
    /// </summary>
    public int ProductoId { get; set; }
    
    /// <summary>
    /// Producto vendido
    /// </summary>
    public virtual Producto Producto { get; set; } = null!;
    
    /// <summary>
    /// Cantidad vendida
    /// </summary>
    public int Cantidad { get; set; }
    
    /// <summary>
    /// Precio unitario al momento de la venta
    /// </summary>
    public decimal PrecioUnitario { get; set; }
    
    /// <summary>
    /// Subtotal del detalle (Cantidad * PrecioUnitario)
    /// </summary>
    public decimal Subtotal => Cantidad * PrecioUnitario;
}
