using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Venta
/// </summary>
public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Ventas");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Total)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(v => v.NumeroComprobante)
            .HasMaxLength(50);
        
        builder.Property(v => v.Observaciones)
            .HasMaxLength(1000);
        
        // Índices
        builder.HasIndex(v => v.Fecha)
            .HasDatabaseName("IX_Venta_Fecha");
        
        builder.HasIndex(v => v.ClienteId)
            .HasDatabaseName("IX_Venta_Cliente");
        
        builder.HasIndex(v => v.EmpleadoId)
            .HasDatabaseName("IX_Venta_Empleado");
        
        // Relaciones
        builder.HasOne(v => v.Cliente)
            .WithMany(c => c.Ventas)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(v => v.Empleado)
            .WithMany(e => e.Ventas)
            .HasForeignKey(v => v.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(v => v.Detalles)
            .WithOne(d => d.Venta)
            .HasForeignKey(d => d.VentaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
