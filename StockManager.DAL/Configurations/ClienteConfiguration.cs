using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Cliente
/// </summary>
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(c => c.Apellido)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(c => c.Documento)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(c => c.Direccion)
            .HasMaxLength(200);
        
        builder.Property(c => c.Telefono)
            .HasMaxLength(20);
        
        builder.Property(c => c.Email)
            .HasMaxLength(100);
        
        // Índice único por documento
        builder.HasIndex(c => c.Documento)
            .IsUnique()
            .HasDatabaseName("IX_Cliente_Documento");
        
        // Índice por estado
        builder.HasIndex(c => c.Estado)
            .HasDatabaseName("IX_Cliente_Estado");
        
        // Relaciones
        builder.HasMany(c => c.Ventas)
            .WithOne(v => v.Cliente)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Ignorar propiedades calculadas
        builder.Ignore(c => c.NombreCompleto);
    }
}
