namespace StockManager.Services.Security;

/// <summary>
/// Interfaz para estrategias de encriptaci�n de contrase�as
/// Patr�n Strategy
/// </summary>
public interface IEncryptionStrategy
{
    /// <summary>
    /// Genera el hash de una contrase�a
    /// </summary>
    string HashPassword(string password);
    
    /// <summary>
    /// Verifica si una contrase�a coincide con el hash
    /// </summary>
    bool VerifyPassword(string password, string hash);
}
