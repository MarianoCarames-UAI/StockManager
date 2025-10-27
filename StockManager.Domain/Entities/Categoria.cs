namespace StockManager.Domain.Entities;

/// <summary>
/// Representa una categor�a de productos
/// </summary>
public class Categoria : BaseEntity
{
    /// <summary>
    /// Nombre de la categor�a
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Descripci�n detallada de la categor�a
    /// </summary>
    public string? Descripcion { get; set; }
    
    /// <summary>
    /// Productos que pertenecen a esta categor�a
    /// </summary>
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
