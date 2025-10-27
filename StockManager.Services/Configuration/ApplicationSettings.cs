using Microsoft.Extensions.Configuration;

namespace StockManager.Services.Configuration;

/// <summary>
/// Configuración global de la aplicación
/// Patrón Singleton
/// </summary>
public sealed class ApplicationSettings
{
    private static readonly Lazy<ApplicationSettings> _instance = 
        new(() => new ApplicationSettings());

    public static ApplicationSettings Instance => _instance.Value;

    private IConfiguration? _configuration;

    private ApplicationSettings()
    {
        LoadConfiguration();
    }

    /// <summary>
    /// Cadena de conexión a SQL Server
    /// </summary>
    public string ConnectionString { get; private set; } = string.Empty;

    /// <summary>
    /// Ruta para archivos de log
    /// </summary>
    public string LogPath { get; private set; } = string.Empty;

    /// <summary>
    /// Ruta para backups
    /// </summary>
    public string BackupPath { get; private set; } = string.Empty;

    /// <summary>
    /// Proveedor de encriptación (BCrypt o PBKDF2)
    /// </summary>
    public string EncryptionProvider { get; private set; } = "BCrypt";

    /// <summary>
    /// Longitud mínima de contraseña
    /// </summary>
    public int PasswordMinLength { get; private set; } = 8;

    /// <summary>
    /// Idioma por defecto
    /// </summary>
    public string DefaultLanguage { get; private set; } = "es-AR";

    /// <summary>
    /// Días de rotación de logs
    /// </summary>
    public int LogRotationDays { get; private set; } = 30;

    /// <summary>
    /// Habilitar logging en base de datos
    /// </summary>
    public bool EnableDatabaseLogging { get; private set; } = false;

    /// <summary>
    /// Habilitar logging en archivo
    /// </summary>
    public bool EnableFileLogging { get; private set; } = true;

    private void LoadConfiguration()
    {
        try
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();

            // Cargar configuraciones
            ConnectionString = _configuration.GetConnectionString("StockManagerDB") 
                ?? "Server=(localdb)\\mssqllocaldb;Database=StockManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            LogPath = _configuration["Logging:LogPath"] 
                ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            BackupPath = _configuration["Backup:BackupPath"] 
                ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");

            EncryptionProvider = _configuration["Security:EncryptionProvider"] ?? "BCrypt";
            
            if (int.TryParse(_configuration["Security:PasswordMinLength"], out int minLength))
                PasswordMinLength = minLength;

            DefaultLanguage = _configuration["Localization:DefaultLanguage"] ?? "es-AR";

            if (int.TryParse(_configuration["Logging:RotationDays"], out int rotationDays))
                LogRotationDays = rotationDays;

            if (bool.TryParse(_configuration["Logging:EnableDatabaseLogging"], out bool enableDbLog))
                EnableDatabaseLogging = enableDbLog;

            if (bool.TryParse(_configuration["Logging:EnableFileLogging"], out bool enableFileLog))
                EnableFileLogging = enableFileLog;
        }
        catch
        {
            // Si falla la carga, usar valores por defecto ya establecidos
        }
    }

    /// <summary>
    /// Recarga la configuración desde el archivo
    /// </summary>
    public void Reload()
    {
        LoadConfiguration();
    }
}
