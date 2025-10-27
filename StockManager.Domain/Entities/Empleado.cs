namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un empleado del sistema
/// </summary>
public class Empleado : BaseEntity
{
    /// <summary>
    /// Nombre del empleado
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Apellido del empleado
    /// </summary>
    public string Apellido { get; set; } = string.Empty;
    
    /// <summary>
    /// Email del empleado (username para login)
    /// </summary>
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Hash de la contraseña
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;
    
    /// <summary>
    /// Fecha de nacimiento
    /// </summary>
    public DateTime? FechaNacimiento { get; set; }
    
    /// <summary>
    /// ID del rol asignado
    /// </summary>
    public int RolId { get; set; }
    
    /// <summary>
    /// Rol del empleado
    /// </summary>
    public virtual Rol Rol { get; set; } = null!;
    
    /// <summary>
    /// Ventas realizadas por el empleado
    /// </summary>
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    
    /// <summary>
    /// Nombre completo del empleado
    /// </summary>
    public string NombreCompleto => $"{Nombre} {Apellido}";
}
