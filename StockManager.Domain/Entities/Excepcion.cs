namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un registro de excepci�n ocurrida en el sistema
/// </summary>
public class Excepcion : BaseEntity
{
    /// <summary>
    /// Mensaje de la excepci�n
    /// </summary>
    public string Mensaje { get; set; } = string.Empty;
    
    /// <summary>
    /// Stack trace completo
    /// </summary>
    public string? StackTrace { get; set; }
    
    /// <summary>
    /// Tipo de excepci�n
    /// </summary>
    public string? TipoExcepcion { get; set; }
    
    /// <summary>
    /// Usuario que estaba logueado al momento de la excepci�n
    /// </summary>
    public string? Usuario { get; set; }
    
    /// <summary>
    /// Contexto donde ocurri� la excepci�n
    /// </summary>
    public string? Contexto { get; set; }
    
    /// <summary>
    /// Inner exception message
    /// </summary>
    public string? InnerException { get; set; }
}
