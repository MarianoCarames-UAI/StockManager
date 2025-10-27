namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un rol de usuario en el sistema
/// </summary>
public class Rol : BaseEntity
{
    /// <summary>
    /// Nombre del rol
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Descripción del rol
    /// </summary>
    public string? Descripcion { get; set; }
    
    /// <summary>
    /// Empleados que tienen este rol
    /// </summary>
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
