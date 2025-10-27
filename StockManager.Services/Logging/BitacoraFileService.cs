using StockManager.Domain.Enums;
using System.Text.Json;

namespace StockManager.Services.Logging;

/// <summary>
/// Implementación de bitácora que escribe en archivos
/// Patrón Strategy - Estrategia de logging a archivo
/// </summary>
public class BitacoraFileService : IBitacoraService
{
    private readonly string _logPath;
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    public BitacoraFileService(string? logPath = null)
    {
        _logPath = logPath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        
        // Crear directorio si no existe
        if (!Directory.Exists(_logPath))
        {
            Directory.CreateDirectory(_logPath);
        }
    }

    public async Task LogAsync(TipoLog tipo, Severidad severidad, string mensaje, string? usuario = null, string? informacionAdicional = null)
    {
        var logEntry = new
        {
            Fecha = DateTime.Now,
            Tipo = tipo.ToString(),
            Severidad = severidad.ToString(),
            Usuario = usuario ?? "Sistema",
            Mensaje = mensaje,
            InformacionAdicional = informacionAdicional
        };

        string fileName = $"StockManager_{DateTime.Now:yyyyMMdd}.log";
        string fullPath = Path.Combine(_logPath, fileName);

        await _semaphore.WaitAsync();
        try
        {
            string logLine = $"[{logEntry.Fecha:yyyy-MM-dd HH:mm:ss}] [{logEntry.Severidad}] [{logEntry.Tipo}] [{logEntry.Usuario}] {logEntry.Mensaje}";
            
            if (!string.IsNullOrEmpty(informacionAdicional))
            {
                logLine += $" | Info: {informacionAdicional}";
            }

            await File.AppendAllTextAsync(fullPath, logLine + Environment.NewLine);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task LogInfoAsync(string mensaje, string? usuario = null)
    {
        await LogAsync(TipoLog.Sistema, Severidad.Baja, mensaje, usuario);
    }

    public async Task LogWarningAsync(string mensaje, string? usuario = null)
    {
        await LogAsync(TipoLog.Sistema, Severidad.Media, mensaje, usuario);
    }

    public async Task LogErrorAsync(string mensaje, string? usuario = null, Exception? exception = null)
    {
        string infoAdicional = exception != null 
            ? $"Exception: {exception.GetType().Name} - {exception.Message}" 
            : null;
        
        await LogAsync(TipoLog.Sistema, Severidad.Alta, mensaje, usuario, infoAdicional);
    }

    public async Task LogExceptionAsync(Exception exception, string? usuario = null, string? contexto = null)
    {
        var exceptionInfo = new
        {
            Contexto = contexto,
            Tipo = exception.GetType().Name,
            Mensaje = exception.Message,
            StackTrace = exception.StackTrace,
            InnerException = exception.InnerException?.Message
        };

        string infoJson = JsonSerializer.Serialize(exceptionInfo);
        
        await LogAsync(TipoLog.Sistema, Severidad.Alta, 
            $"Excepción capturada: {exception.Message}", 
            usuario, 
            infoJson);
    }
}
