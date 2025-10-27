namespace StockManager.Services.Security;

/// <summary>
/// Implementaci�n de encriptaci�n usando BCrypt
/// </summary>
public class BCryptStrategy : IEncryptionStrategy
{
    private const int WorkFactor = 11; // Factor de trabajo (mayor = m�s seguro pero m�s lento)

    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("La contrase�a no puede estar vac�a", nameof(password));

        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    public bool VerifyPassword(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        if (string.IsNullOrWhiteSpace(hash))
            return false;

        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        catch
        {
            return false;
        }
    }
}
