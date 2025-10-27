using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities;

/// <summary>
/// Representa una entrada de stock (compra a proveedor)
/// </summary>
public class EntradaStock : BaseEntity
{
    /// <summary>
    /// ID del producto
    /// </summary>
    public int ProductoId { get; set; }
    
    /// <summary>
    /// Producto asociado
    /// </summary>
    public virtual Producto Producto { get; set; } = null!;
    
    /// <summary>
    /// ID del proveedor
    /// </summary>
    public int ProveedorId { get; set; }
    
    /// <summary>
    /// Proveedor asociado
    /// </summary>
    public virtual Proveedor Proveedor { get; set; } = null!;
    
    /// <summary>
    /// Cantidad ingresada
    /// </summary>
    public int Cantidad { get; set; }
    
    /// <summary>
    /// Precio unitario de compra
    /// </summary>
    public decimal PrecioUnitario { get; set; }
    
    /// <summary>
    /// Tipo de entrada
    /// </summary>
    public TipoMovimientoStock TipoMovimiento { get; set; } = TipoMovimientoStock.Entrada;
    
    /// <summary>
    /// Número de comprobante
    /// </summary>
    public string? NumeroComprobante { get; set; }
    
    /// <summary>
    /// Observaciones adicionales
    /// </summary>
    public string? Observaciones { get; set; }
    
    /// <summary>
    /// Total de la entrada (Cantidad * PrecioUnitario)
    /// </summary>
    public decimal Total => Cantidad * PrecioUnitario;
}
