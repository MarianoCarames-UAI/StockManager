namespace StockManager.Domain.Enums;

/// <summary>
/// Nivel de severidad de un log
/// </summary>
public enum Severidad
{
    /// <summary>
    /// Severidad baja - Informativo
    /// </summary>
    Baja = 1,
    
    /// <summary>
    /// Severidad media - Advertencia
    /// </summary>
    Media = 2,
    
    /// <summary>
    /// Severidad alta - Error crítico
    /// </summary>
    Alta = 3
}
