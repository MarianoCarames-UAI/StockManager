namespace StockManager.Domain.Entities;

/// <summary>
/// Representa una traducción para el sistema multi-idioma
/// </summary>
public class Traduccion : BaseEntity
{
    /// <summary>
    /// Código de idioma (ej: es-AR, en-US)
    /// </summary>
    public string Idioma { get; set; } = string.Empty;
    
    /// <summary>
    /// Clave de la traducción
    /// </summary>
    public string Clave { get; set; } = string.Empty;
    
    /// <summary>
    /// Valor traducido
    /// </summary>
    public string Valor { get; set; } = string.Empty;
}
