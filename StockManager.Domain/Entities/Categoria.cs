namespace StockManager.Domain.Entities;

/// <summary>
/// Representa una categoría de productos
/// </summary>
public class Categoria : BaseEntity
{
    /// <summary>
    /// Nombre de la categoría
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Descripción detallada de la categoría
    /// </summary>
    public string? Descripcion { get; set; }
    
    /// <summary>
    /// Productos que pertenecen a esta categoría
    /// </summary>
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
