namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un producto del inventario
/// </summary>
public class Producto : BaseEntity
{
    /// <summary>
    /// Código único del producto
    /// </summary>
    public string Codigo { get; set; } = string.Empty;
    
    /// <summary>
    /// Nombre del producto
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Descripción detallada del producto
    /// </summary>
    public string? Descripcion { get; set; }
    
    /// <summary>
    /// ID de la categoría a la que pertenece
    /// </summary>
    public int CategoriaId { get; set; }
    
    /// <summary>
    /// Categoría del producto
    /// </summary>
    public virtual Categoria Categoria { get; set; } = null!;
    
    /// <summary>
    /// Precio de venta unitario
    /// </summary>
    public decimal PrecioUnitario { get; set; }
    
    /// <summary>
    /// Costo unitario del producto
    /// </summary>
    public decimal CostoUnitario { get; set; }
    
    /// <summary>
    /// Stock del producto
    /// </summary>
    public virtual Stock? Stock { get; set; }
    
    /// <summary>
    /// Entradas de stock de este producto
    /// </summary>
    public virtual ICollection<EntradaStock> EntradasStock { get; set; } = new List<EntradaStock>();
    
    /// <summary>
    /// Detalles de venta de este producto
    /// </summary>
    public virtual ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();
}
