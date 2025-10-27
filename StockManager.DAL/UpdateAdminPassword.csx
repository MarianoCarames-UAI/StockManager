using Microsoft.EntityFrameworkCore;
using StockManager.DAL.Context;
using StockManager.Services.Configuration;
using StockManager.Services.Security;

// Configurar DbContext
var optionsBuilder = new DbContextOptionsBuilder<StockManagerContext>();
optionsBuilder.UseSqlServer(ApplicationSettings.Instance.ConnectionString);

using var context = new StockManagerContext(optionsBuilder.Options);

Console.WriteLine("=== ACTUALIZAR PASSWORD ADMIN ===");
Console.WriteLine();

// Buscar admin
var admin = await context.Empleados.FindAsync(1);

if (admin == null)
{
    Console.WriteLine("? No se encontró el administrador");
    return;
}

Console.WriteLine($"? Administrador encontrado: {admin.Email}");
Console.WriteLine($"  Hash actual: {admin.PasswordHash}");
Console.WriteLine();

// Generar nuevo hash
var bcrypt = new BCryptStrategy();
var newHash = bcrypt.HashPassword("Admin123!");

Console.WriteLine("Generando nuevo hash BCrypt para 'Admin123!'...");
Console.WriteLine($"  Nuevo hash: {newHash}");
Console.WriteLine();

// Actualizar
admin.PasswordHash = newHash;
await context.SaveChangesAsync();

Console.WriteLine("? Password actualizado correctamente");
Console.WriteLine();

// Verificar
var verified = bcrypt.VerifyPassword("Admin123!", admin.PasswordHash);
Console.WriteLine($"Verificación: {(verified ? "? CORRECTO" : "? ERROR")}");
Console.WriteLine();

Console.WriteLine("=== CREDENCIALES DE ACCESO ===");
Console.WriteLine($"Email: {admin.Email}");
Console.WriteLine("Password: Admin123!");
Console.WriteLine();
