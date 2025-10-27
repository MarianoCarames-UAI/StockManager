namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un registro de excepción ocurrida en el sistema
/// </summary>
public class Excepcion : BaseEntity
{
    /// <summary>
    /// Mensaje de la excepción
    /// </summary>
    public string Mensaje { get; set; } = string.Empty;
    
    /// <summary>
    /// Stack trace completo
    /// </summary>
    public string? StackTrace { get; set; }
    
    /// <summary>
    /// Tipo de excepción
    /// </summary>
    public string? TipoExcepcion { get; set; }
    
    /// <summary>
    /// Usuario que estaba logueado al momento de la excepción
    /// </summary>
    public string? Usuario { get; set; }
    
    /// <summary>
    /// Contexto donde ocurrió la excepción
    /// </summary>
    public string? Contexto { get; set; }
    
    /// <summary>
    /// Inner exception message
    /// </summary>
    public string? InnerException { get; set; }
}
