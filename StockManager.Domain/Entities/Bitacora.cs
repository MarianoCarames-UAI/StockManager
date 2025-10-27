using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities;

/// <summary>
/// Representa un registro de bitácora/log del sistema
/// </summary>
public class Bitacora : BaseEntity
{
    /// <summary>
    /// Tipo de log
    /// </summary>
    public TipoLog TipoLog { get; set; }
    
    /// <summary>
    /// Nivel de severidad
    /// </summary>
    public Severidad Severidad { get; set; }
    
    /// <summary>
    /// Mensaje del log
    /// </summary>
    public string Mensaje { get; set; } = string.Empty;
    
    /// <summary>
    /// Usuario que ejecutó la acción (opcional)
    /// </summary>
    public string? Usuario { get; set; }
    
    /// <summary>
    /// Información adicional en formato JSON
    /// </summary>
    public string? InformacionAdicional { get; set; }
}
