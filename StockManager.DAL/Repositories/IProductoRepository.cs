using StockManager.Domain.Entities;

namespace StockManager.DAL.Repositories;

/// <summary>
/// Interfaz espec�fica para el repositorio de Productos
/// </summary>
public interface IProductoRepository : IRepository<Producto>
{
    /// <summary>
    /// Obtiene productos por categor�a
    /// </summary>
    Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId);
    
    /// <summary>
    /// Obtiene producto por c�digo
    /// </summary>
    Task<Producto?> GetByCodigoAsync(string codigo);
    
    /// <summary>
    /// Obtiene productos con stock bajo
    /// </summary>
    Task<IEnumerable<Producto>> GetProductosStockBajoAsync();
    
    /// <summary>
    /// Busca productos por nombre o descripci�n
    /// </summary>
    Task<IEnumerable<Producto>> BuscarPorNombreAsync(string termino);
}
