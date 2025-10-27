using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Producto
/// </summary>
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Codigo)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(p => p.Descripcion)
            .HasMaxLength(1000);
        
        builder.Property(p => p.PrecioUnitario)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(p => p.CostoUnitario)
            .HasColumnType("decimal(18,2)");
        
        // Índice único por código
        builder.HasIndex(p => p.Codigo)
            .IsUnique()
            .HasDatabaseName("IX_Producto_Codigo");
        
        // Índice por categoría
        builder.HasIndex(p => p.CategoriaId)
            .HasDatabaseName("IX_Producto_Categoria");
        
        // Relaciones
        builder.HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(p => p.Stock)
            .WithOne(s => s.Producto)
            .HasForeignKey<Stock>(s => s.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.EntradasStock)
            .WithOne(e => e.Producto)
            .HasForeignKey(e => e.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(p => p.DetallesVenta)
            .WithOne(d => d.Producto)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
