using StockManager.Services.Tools;

// Generar hash para Admin123!
Console.WriteLine("Generando hash BCrypt para 'Admin123!'...");
Console.WriteLine();

var hash = PasswordHashGenerator.GenerateBCryptHash("Admin123!");
Console.WriteLine("Hash generado:");
Console.WriteLine(hash);
Console.WriteLine();

// Verificar que funciona
var verified = PasswordHashGenerator.VerifyBCrypt("Admin123!", hash);
Console.WriteLine($"Verificación: {(verified ? "? CORRECTO" : "? ERROR")}");
Console.WriteLine();

Console.WriteLine("Copia este hash y actualiza el StockManagerContext.cs:");
Console.WriteLine($"PasswordHash = \"{hash}\"");
