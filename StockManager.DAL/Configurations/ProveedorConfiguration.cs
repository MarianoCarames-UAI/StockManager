using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Proveedor
/// </summary>
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedores");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(p => p.Documento)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(p => p.Direccion)
            .HasMaxLength(200);
        
        builder.Property(p => p.Telefono)
            .HasMaxLength(20);
        
        builder.Property(p => p.Email)
            .HasMaxLength(100);
        
        // Índice único por documento
        builder.HasIndex(p => p.Documento)
            .IsUnique()
            .HasDatabaseName("IX_Proveedor_Documento");
        
        // Relaciones
        builder.HasMany(p => p.EntradasStock)
            .WithOne(e => e.Proveedor)
            .HasForeignKey(e => e.ProveedorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
