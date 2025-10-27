using StockManager.Services.Security;

namespace StockManager.Services.Tools;

/// <summary>
/// Herramienta para generar hashes de contraseñas
/// </summary>
public static class PasswordHashGenerator
{
    /// <summary>
    /// Genera el hash BCrypt de una contraseña
    /// </summary>
    public static string GenerateBCryptHash(string password)
    {
        var bcrypt = new BCryptStrategy();
        return bcrypt.HashPassword(password);
    }

    /// <summary>
    /// Genera el hash PBKDF2 de una contraseña
    /// </summary>
    public static string GeneratePBKDF2Hash(string password)
    {
        var pbkdf2 = new PBKDF2Strategy();
        return pbkdf2.HashPassword(password);
    }

    /// <summary>
    /// Verifica una contraseña con BCrypt
    /// </summary>
    public static bool VerifyBCrypt(string password, string hash)
    {
        var bcrypt = new BCryptStrategy();
        return bcrypt.VerifyPassword(password, hash);
    }

    /// <summary>
    /// Verifica una contraseña con PBKDF2
    /// </summary>
    public static bool VerifyPBKDF2(string password, string hash)
    {
        var pbkdf2 = new PBKDF2Strategy();
        return pbkdf2.VerifyPassword(password, hash);
    }

    // Método de utilidad para testing
    public static void TestPassword()
    {
        string password = "Admin123!";
        
        Console.WriteLine("=== GENERADOR DE HASHES ===");
        Console.WriteLine($"Password original: {password}");
        Console.WriteLine();
        
        // BCrypt
        string bcryptHash = GenerateBCryptHash(password);
        Console.WriteLine("BCrypt Hash:");
        Console.WriteLine(bcryptHash);
        Console.WriteLine($"Verificación BCrypt: {VerifyBCrypt(password, bcryptHash)}");
        Console.WriteLine();
        
        // PBKDF2
        string pbkdf2Hash = GeneratePBKDF2Hash(password);
        Console.WriteLine("PBKDF2 Hash:");
        Console.WriteLine(pbkdf2Hash);
        Console.WriteLine($"Verificación PBKDF2: {VerifyPBKDF2(password, pbkdf2Hash)}");
    }
}
