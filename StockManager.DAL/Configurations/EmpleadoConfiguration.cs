using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Empleado
/// </summary>
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(e => e.Apellido)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);
        
        // Índice único por email
        builder.HasIndex(e => e.Email)
            .IsUnique()
            .HasDatabaseName("IX_Empleado_Email");
        
        // Índice por rol
        builder.HasIndex(e => e.RolId)
            .HasDatabaseName("IX_Empleado_Rol");
        
        // Relaciones
        builder.HasOne(e => e.Rol)
            .WithMany(r => r.Empleados)
            .HasForeignKey(e => e.RolId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(e => e.Ventas)
            .WithOne(v => v.Empleado)
            .HasForeignKey(v => v.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Ignorar propiedades calculadas
        builder.Ignore(e => e.NombreCompleto);
    }
}
