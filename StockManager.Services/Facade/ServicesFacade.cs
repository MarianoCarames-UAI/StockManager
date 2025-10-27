using StockManager.Services.Configuration;
using StockManager.Services.Logging;
using StockManager.Services.Security;

namespace StockManager.Services.Facade;

/// <summary>
/// Fachada para acceder a todos los servicios de infraestructura
/// Patrón Facade - Simplifica el acceso a servicios
/// </summary>
public sealed class ServicesFacade
{
    private static readonly Lazy<ServicesFacade> _instance = 
        new(() => new ServicesFacade());

    public static ServicesFacade Instance => _instance.Value;

    private readonly IEncryptionStrategy _encryptionStrategy;
    private readonly IBitacoraService _bitacoraService;

    private ServicesFacade()
    {
        var settings = ApplicationSettings.Instance;

        // Inicializar estrategia de encriptación según configuración
        _encryptionStrategy = settings.EncryptionProvider.ToLower() switch
        {
            "pbkdf2" => new PBKDF2Strategy(),
            _ => new BCryptStrategy()
        };

        // Inicializar servicio de bitácora
        _bitacoraService = new BitacoraFileService(settings.LogPath);
    }

    /// <summary>
    /// Servicio de encriptación de contraseñas
    /// </summary>
    public IEncryptionStrategy Encryption => _encryptionStrategy;

    /// <summary>
    /// Servicio de bitácora/logging
    /// </summary>
    public IBitacoraService Bitacora => _bitacoraService;

    /// <summary>
    /// Configuración de la aplicación
    /// </summary>
    public ApplicationSettings Settings => ApplicationSettings.Instance;
}
