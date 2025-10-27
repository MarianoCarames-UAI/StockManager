using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad DetalleVenta
/// </summary>
public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("DetallesVenta");
        
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.PrecioUnitario)
            .HasColumnType("decimal(18,2)");
        
        // Índices
        builder.HasIndex(d => d.VentaId)
            .HasDatabaseName("IX_DetalleVenta_Venta");
        
        builder.HasIndex(d => d.ProductoId)
            .HasDatabaseName("IX_DetalleVenta_Producto");
        
        // Relaciones
        builder.HasOne(d => d.Venta)
            .WithMany(v => v.Detalles)
            .HasForeignKey(d => d.VentaId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(d => d.Producto)
            .WithMany(p => p.DetallesVenta)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Ignorar propiedades calculadas
        builder.Ignore(d => d.Subtotal);
    }
}
