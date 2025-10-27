using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad EntradaStock
/// </summary>
public class EntradaStockConfiguration : IEntityTypeConfiguration<EntradaStock>
{
    public void Configure(EntityTypeBuilder<EntradaStock> builder)
    {
        builder.ToTable("EntradasStock");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.PrecioUnitario)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(e => e.NumeroComprobante)
            .HasMaxLength(50);
        
        builder.Property(e => e.Observaciones)
            .HasMaxLength(1000);
        
        // Índices
        builder.HasIndex(e => e.ProductoId)
            .HasDatabaseName("IX_EntradaStock_Producto");
        
        builder.HasIndex(e => e.ProveedorId)
            .HasDatabaseName("IX_EntradaStock_Proveedor");
        
        builder.HasIndex(e => e.FechaCreacion)
            .HasDatabaseName("IX_EntradaStock_Fecha");
        
        // Relaciones
        builder.HasOne(e => e.Producto)
            .WithMany(p => p.EntradasStock)
            .HasForeignKey(e => e.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(e => e.Proveedor)
            .WithMany(p => p.EntradasStock)
            .HasForeignKey(e => e.ProveedorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Ignorar propiedades calculadas
        builder.Ignore(e => e.Total);
    }
}
