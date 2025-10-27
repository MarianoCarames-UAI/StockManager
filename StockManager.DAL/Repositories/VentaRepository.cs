using Microsoft.EntityFrameworkCore;
using StockManager.DAL.Context;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Repositories;

/// <summary>
/// Repositorio específico para Ventas
/// </summary>
public class VentaRepository : Repository<Venta>, IVentaRepository
{
    public VentaRepository(StockManagerContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Venta>> GetByClienteAsync(int clienteId)
    {
        return await _dbSet
            .Include(v => v.Cliente)
            .Include(v => v.Empleado)
            .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
            .Where(v => v.ClienteId == clienteId && v.Activo)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<IEnumerable<Venta>> GetByEmpleadoAsync(int empleadoId)
    {
        return await _dbSet
            .Include(v => v.Cliente)
            .Include(v => v.Empleado)
            .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
            .Where(v => v.EmpleadoId == empleadoId && v.Activo)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<IEnumerable<Venta>> GetByFechaRangoAsync(DateTime desde, DateTime hasta)
    {
        return await _dbSet
            .Include(v => v.Cliente)
            .Include(v => v.Empleado)
            .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
            .Where(v => v.Fecha >= desde && v.Fecha <= hasta && v.Activo)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalVentasPeriodoAsync(DateTime desde, DateTime hasta)
    {
        return await _dbSet
            .Where(v => v.Fecha >= desde && v.Fecha <= hasta && v.Activo)
            .SumAsync(v => v.Total);
    }

    public async Task<Venta?> GetVentaConDetallesAsync(int ventaId)
    {
        return await _dbSet
            .Include(v => v.Cliente)
            .Include(v => v.Empleado)
            .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                    .ThenInclude(p => p.Categoria)
            .SingleOrDefaultAsync(v => v.Id == ventaId);
    }

    public override async Task<Venta?> GetByIdAsync(int id)
    {
        return await GetVentaConDetallesAsync(id);
    }

    public override async Task<IEnumerable<Venta>> GetAllActiveAsync()
    {
        return await _dbSet
            .Include(v => v.Cliente)
            .Include(v => v.Empleado)
            .Where(v => v.Activo)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }
}
