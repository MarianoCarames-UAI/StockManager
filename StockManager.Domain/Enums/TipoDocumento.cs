namespace StockManager.Domain.Enums;

/// <summary>
/// Tipos de documentos de identificaci�n para clientes y proveedores
/// </summary>
public enum TipoDocumento
{
    /// <summary>
    /// Documento Nacional de Identidad
    /// </summary>
    DNI = 1,
    
    /// <summary>
    /// Clave �nica de Identificaci�n Tributaria
    /// </summary>
    CUIT = 2,
    
    /// <summary>
    /// Clave �nica de Identificaci�n Laboral
    /// </summary>
    CUIL = 3,
    
    /// <summary>
    /// Pasaporte
    /// </summary>
    Pasaporte = 4
}
