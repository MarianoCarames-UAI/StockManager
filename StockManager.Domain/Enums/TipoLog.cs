namespace StockManager.Domain.Enums;

/// <summary>
/// Tipos de log/bitácora
/// </summary>
public enum TipoLog
{
    /// <summary>
    /// Log de operaciones de usuario (login, ABM, etc.)
    /// </summary>
    Usuario = 1,
    
    /// <summary>
    /// Log de operaciones del sistema (backup, errores, etc.)
    /// </summary>
    Sistema = 2
}
