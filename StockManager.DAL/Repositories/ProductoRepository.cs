using Microsoft.EntityFrameworkCore;
using StockManager.DAL.Context;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Repositories;

/// <summary>
/// Repositorio específico para Productos
/// </summary>
public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    public ProductoRepository(StockManagerContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId)
    {
        return await _dbSet
            .Include(p => p.Categoria)
            .Include(p => p.Stock)
            .Where(p => p.CategoriaId == categoriaId && p.Activo)
            .ToListAsync();
    }

    public async Task<Producto?> GetByCodigoAsync(string codigo)
    {
        return await _dbSet
            .Include(p => p.Categoria)
            .Include(p => p.Stock)
            .SingleOrDefaultAsync(p => p.Codigo == codigo && p.Activo);
    }

    public async Task<IEnumerable<Producto>> GetProductosStockBajoAsync()
    {
        return await _dbSet
            .Include(p => p.Categoria)
            .Include(p => p.Stock)
            .Where(p => p.Activo && 
                       p.Stock != null && 
                       p.Stock.CantidadActual <= p.Stock.CantidadReorden)
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto>> BuscarPorNombreAsync(string termino)
    {
        return await _dbSet
            .Include(p => p.Categoria)
            .Include(p => p.Stock)
            .Where(p => p.Activo && 
                       (p.Nombre.Contains(termino) || 
                        (p.Descripcion != null && p.Descripcion.Contains(termino))))
            .ToListAsync();
    }

    public override async Task<Producto?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Categoria)
            .Include(p => p.Stock)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Producto>> GetAllActiveAsync()
    {
        return await _dbSet
            .Include(p => p.Categoria)
            .Include(p => p.Stock)
            .Where(p => p.Activo)
            .ToListAsync();
    }
}
