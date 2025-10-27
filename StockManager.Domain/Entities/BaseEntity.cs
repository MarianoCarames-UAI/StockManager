namespace StockManager.Domain.Entities;

/// <summary>
/// Clase base abstracta para todas las entidades del dominio
/// Contiene propiedades comunes de auditoría y estado
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Identificador único de la entidad
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Fecha y hora de creación del registro
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    
    /// <summary>
    /// Fecha y hora de última modificación del registro
    /// </summary>
    public DateTime? FechaModificacion { get; set; }
    
    /// <summary>
    /// Indica si el registro está activo (soft delete)
    /// </summary>
    public bool Activo { get; set; } = true;
}
