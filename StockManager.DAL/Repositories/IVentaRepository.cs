using StockManager.Domain.Entities;

namespace StockManager.DAL.Repositories;

/// <summary>
/// Interfaz específica para el repositorio de Ventas
/// </summary>
public interface IVentaRepository : IRepository<Venta>
{
    /// <summary>
    /// Obtiene ventas por cliente
    /// </summary>
    Task<IEnumerable<Venta>> GetByClienteAsync(int clienteId);
    
    /// <summary>
    /// Obtiene ventas por empleado
    /// </summary>
    Task<IEnumerable<Venta>> GetByEmpleadoAsync(int empleadoId);
    
    /// <summary>
    /// Obtiene ventas por rango de fechas
    /// </summary>
    Task<IEnumerable<Venta>> GetByFechaRangoAsync(DateTime desde, DateTime hasta);
    
    /// <summary>
    /// Obtiene el total de ventas por período
    /// </summary>
    Task<decimal> GetTotalVentasPeriodoAsync(DateTime desde, DateTime hasta);
    
    /// <summary>
    /// Obtiene venta con todos sus detalles
    /// </summary>
    Task<Venta?> GetVentaConDetallesAsync(int ventaId);
}
