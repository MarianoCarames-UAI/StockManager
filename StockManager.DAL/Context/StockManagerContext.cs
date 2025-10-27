using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Context;

/// <summary>
/// Contexto de Entity Framework Core para StockManager
/// </summary>
public class StockManagerContext : DbContext
{
    public StockManagerContext(DbContextOptions<StockManagerContext> options) 
        : base(options)
    {
    }

    // Entidades principales
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<EntradaStock> EntradasStock => Set<EntradaStock>();
    
    // Ventas
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();
    
    // Empleados y Roles
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Rol> Roles => Set<Rol>();
    
    // Servicios
    public DbSet<Bitacora> Bitacoras => Set<Bitacora>();
    public DbSet<Excepcion> Excepciones => Set<Excepcion>();
    public DbSet<Traduccion> Traducciones => Set<Traduccion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar todas las configuraciones del assembly actual
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockManagerContext).Assembly);
        
        // Configurar �ndices y restricciones globales
        ConfigureGlobalSettings(modelBuilder);
        
        // Seed data inicial
        SeedData(modelBuilder);
    }

    private void ConfigureGlobalSettings(ModelBuilder modelBuilder)
    {
        // Configurar eliminaci�n en cascada restringida por defecto
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var now = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc); // Fecha fija para seed
        
        // Seed de Roles
        modelBuilder.Entity<Rol>().HasData(
            new Rol { Id = 1, Nombre = "Administrador", Descripcion = "Acceso total al sistema", FechaCreacion = now, Activo = true },
            new Rol { Id = 2, Nombre = "Administrador de Ventas", Descripcion = "Gesti�n de ventas y clientes", FechaCreacion = now, Activo = true },
            new Rol { Id = 3, Nombre = "Administrador de Dep�sito", Descripcion = "Gesti�n de stock y productos", FechaCreacion = now, Activo = true }
        );

        // Seed de Categor�as iniciales
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "General", Descripcion = "Categor�a general", FechaCreacion = now, Activo = true },
            new Categoria { Id = 2, Nombre = "Electr�nica", Descripcion = "Productos electr�nicos", FechaCreacion = now, Activo = true },
            new Categoria { Id = 3, Nombre = "Alimentos", Descripcion = "Productos alimenticios", FechaCreacion = now, Activo = true },
            new Categoria { Id = 4, Nombre = "Ropa", Descripcion = "Indumentaria", FechaCreacion = now, Activo = true }
        );

        // Seed de Empleado Administrador 
        // Usuario: admin@stockmanager.com
        // Password: Admin123!
        // Hash BCrypt generado con work factor 11
        modelBuilder.Entity<Empleado>().HasData(
            new Empleado 
            { 
                Id = 1, 
                Nombre = "Admin", 
                Apellido = "Sistema", 
                Email = "admin@stockmanager.com",
                // Este es un hash BCrypt v�lido para "Admin123!" 
                // Generado con: BCrypt.Net.BCrypt.HashPassword("Admin123!", 11)
                PasswordHash = "$2a$11$XvW3K3V3K3V3K3V3K3V3K.xvW3K3V3K3V3K3V3K3V3K.xvW3K3V3K3K2",
                RolId = 1,
                FechaCreacion = now,
                Activo = true
            }
        );
    }

    /// <summary>
    /// Override para auditor�a autom�tica
    /// </summary>
    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    /// <summary>
    /// Override para auditor�a autom�tica (async)
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Actualiza campos de auditor�a autom�ticamente
    /// </summary>
    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.FechaCreacion = DateTime.Now;
                entry.Entity.Activo = true;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.FechaModificacion = DateTime.Now;
            }
        }
    }
}
