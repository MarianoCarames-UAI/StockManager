namespace StockManager.Domain.Entities;

/// <summary>
/// Clase base abstracta para todas las entidades del dominio
/// Contiene propiedades comunes de auditor�a y estado
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Identificador �nico de la entidad
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Fecha y hora de creaci�n del registro
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    
    /// <summary>
    /// Fecha y hora de �ltima modificaci�n del registro
    /// </summary>
    public DateTime? FechaModificacion { get; set; }
    
    /// <summary>
    /// Indica si el registro est� activo (soft delete)
    /// </summary>
    public bool Activo { get; set; } = true;
}
