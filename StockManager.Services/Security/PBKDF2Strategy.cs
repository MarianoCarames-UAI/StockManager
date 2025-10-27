using System.Security.Cryptography;
using System.Text;

namespace StockManager.Services.Security;

/// <summary>
/// Implementación de encriptación usando PBKDF2
/// Estrategia alternativa a BCrypt
/// </summary>
public class PBKDF2Strategy : IEncryptionStrategy
{
    private const int SaltSize = 16; // 128 bits
    private const int HashSize = 20; // 160 bits
    private const int Iterations = 10000;

    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("La contraseña no puede estar vacía", nameof(password));

        // Generar salt aleatorio
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        
        // Generar hash
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Combinar salt + hash
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        // Convertir a Base64
        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
            return false;

        try
        {
            // Extraer bytes del hash almacenado
            byte[] hashBytes = Convert.FromBase64String(hash);

            // Extraer salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Generar hash con el password proporcionado
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] computedHash = pbkdf2.GetBytes(HashSize);

            // Comparar hashes
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != computedHash[i])
                    return false;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}
