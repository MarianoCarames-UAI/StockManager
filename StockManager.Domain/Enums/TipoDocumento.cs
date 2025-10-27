namespace StockManager.Domain.Enums;

/// <summary>
/// Tipos de documentos de identificación para clientes y proveedores
/// </summary>
public enum TipoDocumento
{
    /// <summary>
    /// Documento Nacional de Identidad
    /// </summary>
    DNI = 1,
    
    /// <summary>
    /// Clave Única de Identificación Tributaria
    /// </summary>
    CUIT = 2,
    
    /// <summary>
    /// Clave Única de Identificación Laboral
    /// </summary>
    CUIL = 3,
    
    /// <summary>
    /// Pasaporte
    /// </summary>
    Pasaporte = 4
}
