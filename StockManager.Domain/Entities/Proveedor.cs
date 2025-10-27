using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un proveedor de productos
/// </summary>
public class Proveedor : BaseEntity
{
    /// <summary>
    /// Nombre o razón social del proveedor
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Tipo de documento
    /// </summary>
    public TipoDocumento TipoDocumento { get; set; }
    
    /// <summary>
    /// Número de documento (CUIT/DNI)
    /// </summary>
    public string Documento { get; set; } = string.Empty;
    
    /// <summary>
    /// Dirección del proveedor
    /// </summary>
    public string? Direccion { get; set; }
    
    /// <summary>
    /// Teléfono de contacto
    /// </summary>
    public string? Telefono { get; set; }
    
    /// <summary>
    /// Email del proveedor
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Entradas de stock realizadas por este proveedor
    /// </summary>
    public virtual ICollection<EntradaStock> EntradasStock { get; set; } = new List<EntradaStock>();
}
