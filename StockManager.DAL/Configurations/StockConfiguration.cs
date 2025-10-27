using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Stock
/// </summary>
public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");
        
        builder.HasKey(s => s.Id);
        
        // Índice único por producto
        builder.HasIndex(s => s.ProductoId)
            .IsUnique()
            .HasDatabaseName("IX_Stock_Producto");
        
        // Relaciones
        builder.HasOne(s => s.Producto)
            .WithOne(p => p.Stock)
            .HasForeignKey<Stock>(s => s.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Ignorar propiedades calculadas
        builder.Ignore(s => s.RequiereReorden);
    }
}
