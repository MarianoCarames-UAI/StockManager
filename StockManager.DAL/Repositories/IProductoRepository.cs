using StockManager.Domain.Entities;

namespace StockManager.DAL.Repositories;

/// <summary>
/// Interfaz específica para el repositorio de Productos
/// </summary>
public interface IProductoRepository : IRepository<Producto>
{
    /// <summary>
    /// Obtiene productos por categoría
    /// </summary>
    Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId);
    
    /// <summary>
    /// Obtiene producto por código
    /// </summary>
    Task<Producto?> GetByCodigoAsync(string codigo);
    
    /// <summary>
    /// Obtiene productos con stock bajo
    /// </summary>
    Task<IEnumerable<Producto>> GetProductosStockBajoAsync();
    
    /// <summary>
    /// Busca productos por nombre o descripción
    /// </summary>
    Task<IEnumerable<Producto>> BuscarPorNombreAsync(string termino);
}
