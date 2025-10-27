using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Configurations;

/// <summary>
/// Configuración de la entidad Categoria
/// </summary>
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(c => c.Descripcion)
            .HasMaxLength(500);
        
        // Índice único por nombre
        builder.HasIndex(c => c.Nombre)
            .IsUnique()
            .HasDatabaseName("IX_Categoria_Nombre");
        
        // Relaciones
        builder.HasMany(c => c.Productos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
