using Microsoft.EntityFrameworkCore.Storage;
using StockManager.DAL.Context;
using StockManager.DAL.Repositories;
using StockManager.Domain.Entities;

namespace StockManager.DAL.UnitOfWork;

/// <summary>
/// Implementación del patrón Unit of Work
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly StockManagerContext _context;
    private IDbContextTransaction? _transaction;

    // Repositorios
    private IRepository<Cliente>? _clientes;
    private IRepository<Categoria>? _categorias;
    private IProductoRepository? _productos;
    private IRepository<Stock>? _stocks;
    private IRepository<Proveedor>? _proveedores;
    private IRepository<EntradaStock>? _entradasStock;
    private IVentaRepository? _ventas;
    private IRepository<DetalleVenta>? _detallesVenta;
    private IRepository<Empleado>? _empleados;
    private IRepository<Rol>? _roles;
    private IRepository<Bitacora>? _bitacoras;
    private IRepository<Excepcion>? _excepciones;
    private IRepository<Traduccion>? _traducciones;

    public UnitOfWork(StockManagerContext context)
    {
        _context = context;
    }

    public IRepository<Cliente> Clientes => 
        _clientes ??= new Repository<Cliente>(_context);

    public IRepository<Categoria> Categorias => 
        _categorias ??= new Repository<Categoria>(_context);

    public IProductoRepository Productos => 
        _productos ??= new ProductoRepository(_context);

    public IRepository<Stock> Stocks => 
        _stocks ??= new Repository<Stock>(_context);

    public IRepository<Proveedor> Proveedores => 
        _proveedores ??= new Repository<Proveedor>(_context);

    public IRepository<EntradaStock> EntradasStock => 
        _entradasStock ??= new Repository<EntradaStock>(_context);

    public IVentaRepository Ventas => 
        _ventas ??= new VentaRepository(_context);

    public IRepository<DetalleVenta> DetallesVenta => 
        _detallesVenta ??= new Repository<DetalleVenta>(_context);

    public IRepository<Empleado> Empleados => 
        _empleados ??= new Repository<Empleado>(_context);

    public IRepository<Rol> Roles => 
        _roles ??= new Repository<Rol>(_context);

    public IRepository<Bitacora> Bitacoras => 
        _bitacoras ??= new Repository<Bitacora>(_context);

    public IRepository<Excepcion> Excepciones => 
        _excepciones ??= new Repository<Excepcion>(_context);

    public IRepository<Traduccion> Traducciones => 
        _traducciones ??= new Repository<Traduccion>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
