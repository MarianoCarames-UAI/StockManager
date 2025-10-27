using Microsoft.EntityFrameworkCore;
using StockManager.DAL.Context;
using StockManager.Services.Configuration;
using StockManager.Services.Security;

Console.WriteLine("=== STOCK MANAGER - ACTUALIZAR PASSWORD ADMIN ===");
Console.WriteLine();

try
{
    // Configurar DbContext
    var optionsBuilder = new DbContextOptionsBuilder<StockManagerContext>();
    optionsBuilder.UseSqlServer(ApplicationSettings.Instance.ConnectionString);

    using var context = new StockManagerContext(optionsBuilder.Options);

    // Buscar admin
    var admin = await context.Empleados.FindAsync(1);

    if (admin == null)
    {
        Console.WriteLine("? ERROR: No se encontró el administrador con Id = 1");
        return 1;
    }

    Console.WriteLine($"? Administrador encontrado:");
    Console.WriteLine($"  ID: {admin.Id}");
    Console.WriteLine($"  Email: {admin.Email}");
    Console.WriteLine($"  Nombre: {admin.NombreCompleto}");
    Console.WriteLine();

    // Generar nuevo hash BCrypt
    Console.WriteLine("Generando hash BCrypt para 'Admin123!'...");
    var bcrypt = new BCryptStrategy();
    var newHash = bcrypt.HashPassword("Admin123!");

    Console.WriteLine($"? Hash generado exitosamente");
    Console.WriteLine($"  Hash: {newHash}");
    Console.WriteLine();

    // Actualizar password
    Console.WriteLine("Actualizando password en base de datos...");
    admin.PasswordHash = newHash;
    admin.FechaModificacion = DateTime.Now;
    
    await context.SaveChangesAsync();
    Console.WriteLine("? Password actualizado correctamente");
    Console.WriteLine();

    // Verificar que funciona
    Console.WriteLine("Verificando hash...");
    var verified = bcrypt.VerifyPassword("Admin123!", admin.PasswordHash);
    
    if (verified)
    {
        Console.WriteLine("? VERIFICACIÓN EXITOSA");
        Console.WriteLine();
        Console.WriteLine("=== CREDENCIALES DE ACCESO ===");
        Console.WriteLine($"  Email:    {admin.Email}");
        Console.WriteLine( "  Password: Admin123!");
        Console.WriteLine();
        Console.WriteLine("? El administrador ya puede iniciar sesión en la aplicación");
        return 0;
    }
    else
    {
        Console.WriteLine("? ERROR: La verificación del hash falló");
        return 1;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"? ERROR: {ex.Message}");
    Console.WriteLine();
    Console.WriteLine("Stack Trace:");
    Console.WriteLine(ex.StackTrace);
    return 1;
}
