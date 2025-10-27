namespace StockManager.Services.Security;

/// <summary>
/// Interfaz para estrategias de encriptación de contraseñas
/// Patrón Strategy
/// </summary>
public interface IEncryptionStrategy
{
    /// <summary>
    /// Genera el hash de una contraseña
    /// </summary>
    string HashPassword(string password);
    
    /// <summary>
    /// Verifica si una contraseña coincide con el hash
    /// </summary>
    bool VerifyPassword(string password, string hash);
}
