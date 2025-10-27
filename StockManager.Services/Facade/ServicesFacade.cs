using StockManager.Services.Configuration;
using StockManager.Services.Logging;
using StockManager.Services.Security;

namespace StockManager.Services.Facade;

/// <summary>
/// Fachada para acceder a todos los servicios de infraestructura
/// Patr�n Facade - Simplifica el acceso a servicios
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

        // Inicializar estrategia de encriptaci�n seg�n configuraci�n
        _encryptionStrategy = settings.EncryptionProvider.ToLower() switch
        {
            "pbkdf2" => new PBKDF2Strategy(),
            _ => new BCryptStrategy()
        };

        // Inicializar servicio de bit�cora
        _bitacoraService = new BitacoraFileService(settings.LogPath);
    }

    /// <summary>
    /// Servicio de encriptaci�n de contrase�as
    /// </summary>
    public IEncryptionStrategy Encryption => _encryptionStrategy;

    /// <summary>
    /// Servicio de bit�cora/logging
    /// </summary>
    public IBitacoraService Bitacora => _bitacoraService;

    /// <summary>
    /// Configuraci�n de la aplicaci�n
    /// </summary>
    public ApplicationSettings Settings => ApplicationSettings.Instance;
}
