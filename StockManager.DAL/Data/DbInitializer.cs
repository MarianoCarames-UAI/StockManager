using Microsoft.EntityFrameworkCore;
using StockManager.DAL.Context;
using StockManager.Domain.Entities;
using StockManager.Services.Security;

namespace StockManager.DAL.Data;

/// <summary>
/// Inicializador de base de datos con datos de prueba
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Inicializa la base de datos con datos de seed
    /// </summary>
    public static async Task InitializeAsync(StockManagerContext context, bool recreate = false)
    {
        if (recreate)
        {
            await context.Database.EnsureDeletedAsync();
        }

        // Aplicar migraciones pendientes
        await context.Database.MigrateAsync();

        // Verificar si ya tiene datos
        if (await context.Empleados.AnyAsync())
        {
            return; // Ya tiene datos
        }

        // Si no tiene datos, actualizar el hash del admin
        await UpdateAdminPasswordAsync(context);
    }

    /// <summary>
    /// Actualiza el password del administrador con un hash válido
    /// </summary>
    public static async Task UpdateAdminPasswordAsync(StockManagerContext context)
    {
        var admin = await context.Empleados.FindAsync(1);
        if (admin != null)
        {
            var encryption = new BCryptStrategy();
            admin.PasswordHash = encryption.HashPassword("Admin123!");
            await context.SaveChangesAsync();
            
            Console.WriteLine("? Password del administrador actualizado correctamente");
            Console.WriteLine($"  Email: {admin.Email}");
            Console.WriteLine("  Password: Admin123!");
        }
    }

    /// <summary>
    /// Agrega datos de prueba a la base de datos
    /// </summary>
    public static async Task SeedTestDataAsync(StockManagerContext context)
    {
        // Verificar que existen las categorías
        if (!await context.Categorias.AnyAsync())
        {
            return; // No hay categorías, no se puede continuar
        }

        // Agregar productos de prueba
        if (!await context.Productos.AnyAsync())
        {
            var productos = new[]
            {
                new Producto 
                { 
                    Codigo = "PROD001", 
                    Nombre = "Laptop Dell", 
                    Descripcion = "Laptop Dell Inspiron 15", 
                    CategoriaId = 2, 
                    PrecioUnitario = 850000, 
                    CostoUnitario = 650000,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                },
                new Producto 
                { 
                    Codigo = "PROD002", 
                    Nombre = "Mouse Logitech", 
                    Descripcion = "Mouse inalámbrico Logitech MX Master 3", 
                    CategoriaId = 2, 
                    PrecioUnitario = 15000, 
                    CostoUnitario = 10000,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                },
                new Producto 
                { 
                    Codigo = "PROD003", 
                    Nombre = "Teclado Mecánico", 
                    Descripcion = "Teclado mecánico RGB", 
                    CategoriaId = 2, 
                    PrecioUnitario = 25000, 
                    CostoUnitario = 18000,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                },
                new Producto 
                { 
                    Codigo = "PROD004", 
                    Nombre = "Remera Básica", 
                    Descripcion = "Remera de algodón", 
                    CategoriaId = 4, 
                    PrecioUnitario = 5000, 
                    CostoUnitario = 3000,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                }
            };

            await context.Productos.AddRangeAsync(productos);
            await context.SaveChangesAsync();

            // Agregar stock inicial
            foreach (var producto in productos)
            {
                var stock = new Stock
                {
                    ProductoId = producto.Id,
                    CantidadActual = 100,
                    CantidadReorden = 10,
                    FechaUltimoIngreso = DateTime.Now,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };
                await context.Stocks.AddAsync(stock);
            }

            await context.SaveChangesAsync();
            Console.WriteLine($"? Agregados {productos.Length} productos de prueba con stock");
        }

        // Agregar clientes de prueba
        if (!await context.Clientes.AnyAsync())
        {
            var clientes = new[]
            {
                new Cliente
                {
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    TipoDocumento = Domain.Enums.TipoDocumento.DNI,
                    Documento = "12345678",
                    Direccion = "Av. Corrientes 1234",
                    Telefono = "1234-5678",
                    Email = "juan.perez@email.com",
                    Estado = Domain.Enums.EstadoCliente.Activo,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                },
                new Cliente
                {
                    Nombre = "María",
                    Apellido = "González",
                    TipoDocumento = Domain.Enums.TipoDocumento.DNI,
                    Documento = "87654321",
                    Direccion = "Av. Santa Fe 5678",
                    Telefono = "8765-4321",
                    Email = "maria.gonzalez@email.com",
                    Estado = Domain.Enums.EstadoCliente.Activo,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                }
            };

            await context.Clientes.AddRangeAsync(clientes);
            await context.SaveChangesAsync();
            Console.WriteLine($"? Agregados {clientes.Length} clientes de prueba");
        }

        // Agregar proveedores de prueba
        if (!await context.Proveedores.AnyAsync())
        {
            var proveedores = new[]
            {
                new Proveedor
                {
                    Nombre = "Distribuidora Tech SA",
                    TipoDocumento = Domain.Enums.TipoDocumento.CUIT,
                    Documento = "30-12345678-9",
                    Direccion = "Av. Industrial 1000",
                    Telefono = "4000-1000",
                    Email = "ventas@distribuidoratech.com",
                    Activo = true,
                    FechaCreacion = DateTime.Now
                },
                new Proveedor
                {
                    Nombre = "Textiles del Sur",
                    TipoDocumento = Domain.Enums.TipoDocumento.CUIT,
                    Documento = "30-98765432-1",
                    Direccion = "Calle Comercio 500",
                    Telefono = "4000-2000",
                    Email = "contacto@textilesdelsur.com",
                    Activo = true,
                    FechaCreacion = DateTime.Now
                }
            };

            await context.Proveedores.AddRangeAsync(proveedores);
            await context.SaveChangesAsync();
            Console.WriteLine($"? Agregados {proveedores.Length} proveedores de prueba");
        }

        Console.WriteLine("? Base de datos inicializada con datos de prueba");
    }
}
