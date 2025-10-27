using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Rol
/// </summary>
public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Roles");
        
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Nombre)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(r => r.Descripcion)
            .HasMaxLength(500);
        
        // Índice único por nombre
        builder.HasIndex(r => r.Nombre)
            .IsUnique()
            .HasDatabaseName("IX_Rol_Nombre");
        
        // Relaciones
        builder.HasMany(r => r.Empleados)
            .WithOne(e => e.Rol)
            .HasForeignKey(e => e.RolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
