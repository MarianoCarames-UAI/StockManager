using StockManager.DAL.Repositories;
using StockManager.Domain.Entities;

namespace StockManager.DAL.UnitOfWork;

/// <summary>
/// Interfaz del patrón Unit of Work
/// Agrupa todos los repositorios y maneja transacciones
/// </summary>
public interface IUnitOfWork : IDisposable
{
    // Repositorios específicos
    IRepository<Cliente> Clientes { get; }
    IRepository<Categoria> Categorias { get; }
    IProductoRepository Productos { get; }
    IRepository<Stock> Stocks { get; }
    IRepository<Proveedor> Proveedores { get; }
    IRepository<EntradaStock> EntradasStock { get; }
    IVentaRepository Ventas { get; }
    IRepository<DetalleVenta> DetallesVenta { get; }
    IRepository<Empleado> Empleados { get; }
    IRepository<Rol> Roles { get; }
    IRepository<Bitacora> Bitacoras { get; }
    IRepository<Excepcion> Excepciones { get; }
    IRepository<Traduccion> Traducciones { get; }

    /// <summary>
    /// Guarda todos los cambios en la base de datos
    /// </summary>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Inicia una transacción
    /// </summary>
    Task BeginTransactionAsync();

    /// <summary>
    /// Confirma la transacción actual
    /// </summary>
    Task CommitAsync();

    /// <summary>
    /// Revierte la transacción actual
    /// </summary>
    Task RollbackAsync();
}
