namespace StockManager.Domain.Entities;

/// <summary>
/// Representa el stock actual de un producto
/// </summary>
public class Stock : BaseEntity
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
    /// Cantidad actual en stock
    /// </summary>
    public int CantidadActual { get; set; }
    
    /// <summary>
    /// Cantidad mínima de reorden (alerta)
    /// </summary>
    public int CantidadReorden { get; set; }
    
    /// <summary>
    /// Fecha de último ingreso
    /// </summary>
    public DateTime FechaUltimoIngreso { get; set; }
    
    /// <summary>
    /// Fecha de última salida
    /// </summary>
    public DateTime? FechaUltimaSalida { get; set; }
    
    /// <summary>
    /// Indica si el stock está por debajo del nivel de reorden
    /// </summary>
    public bool RequiereReorden => CantidadActual <= CantidadReorden;
}
