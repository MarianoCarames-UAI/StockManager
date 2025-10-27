using StockManager.Domain.Enums;

namespace StockManager.Services.Logging;

/// <summary>
/// Interfaz para el servicio de bitácora/logging
/// </summary>
public interface IBitacoraService
{
    /// <summary>
    /// Registra un log en el sistema
    /// </summary>
    Task LogAsync(TipoLog tipo, Severidad severidad, string mensaje, string? usuario = null, string? informacionAdicional = null);
    
    /// <summary>
    /// Registra un log informativo
    /// </summary>
    Task LogInfoAsync(string mensaje, string? usuario = null);
    
    /// <summary>
    /// Registra un log de advertencia
    /// </summary>
    Task LogWarningAsync(string mensaje, string? usuario = null);
    
    /// <summary>
    /// Registra un log de error
    /// </summary>
    Task LogErrorAsync(string mensaje, string? usuario = null, Exception? exception = null);
    
    /// <summary>
    /// Registra una excepción
    /// </summary>
    Task LogExceptionAsync(Exception exception, string? usuario = null, string? contexto = null);
}
