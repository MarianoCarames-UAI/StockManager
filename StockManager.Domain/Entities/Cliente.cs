using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un cliente del sistema
/// </summary>
public class Cliente : BaseEntity
{
    /// <summary>
    /// Nombre del cliente
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Apellido del cliente
    /// </summary>
    public string Apellido { get; set; } = string.Empty;
    
    /// <summary>
    /// Tipo de documento de identificación
    /// </summary>
    public TipoDocumento TipoDocumento { get; set; }
    
    /// <summary>
    /// Número de documento
    /// </summary>
    public string Documento { get; set; } = string.Empty;
    
    /// <summary>
    /// Dirección del cliente
    /// </summary>
    public string? Direccion { get; set; }
    
    /// <summary>
    /// Teléfono de contacto
    /// </summary>
    public string? Telefono { get; set; }
    
    /// <summary>
    /// Email del cliente
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Estado actual del cliente
    /// </summary>
    public EstadoCliente Estado { get; set; } = EstadoCliente.Activo;
    
    /// <summary>
    /// Ventas realizadas por el cliente
    /// </summary>
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    
    /// <summary>
    /// Nombre completo del cliente
    /// </summary>
    public string NombreCompleto => $"{Nombre} {Apellido}";
}
