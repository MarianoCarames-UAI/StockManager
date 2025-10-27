namespace StockManager.Domain.Entities;

/// <summary>
/// Representa una traducci�n para el sistema multi-idioma
/// </summary>
public class Traduccion : BaseEntity
{
    /// <summary>
    /// C�digo de idioma (ej: es-AR, en-US)
    /// </summary>
    public string Idioma { get; set; } = string.Empty;
    
    /// <summary>
    /// Clave de la traducci�n
    /// </summary>
    public string Clave { get; set; } = string.Empty;
    
    /// <summary>
    /// Valor traducido
    /// </summary>
    public string Valor { get; set; } = string.Empty;
}
