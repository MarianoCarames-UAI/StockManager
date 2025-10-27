using Microsoft.EntityFrameworkCore;
using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.DAL.UnitOfWork;
using StockManager.Domain.Entities;
using StockManager.Domain.Enums;
using StockManager.Services.Facade;

namespace StockManager.BLL.Services;

/// <summary>
/// Servicio de negocio para gestión de productos
/// </summary>
public class ProductoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ServicesFacade _services;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _services = ServicesFacade.Instance;
    }

    /// <summary>
    /// Obtiene todos los productos activos
    /// </summary>
    public async Task<Result<List<ProductoDTO>>> ObtenerTodosAsync()
    {
        try
        {
            var productos = await _unitOfWork.Productos.GetAllActiveAsync();
            
            var productosDto = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria?.Nombre ?? "Sin categoría",
                PrecioUnitario = p.PrecioUnitario,
                CostoUnitario = p.CostoUnitario,
                StockActual = p.Stock?.CantidadActual ?? 0,
                StockMinimo = p.Stock?.CantidadReorden ?? 0
            }).ToList();

            return Result<List<ProductoDTO>>.Success(productosDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.ObtenerTodosAsync");
            return Result<List<ProductoDTO>>.Failure($"Error al obtener productos: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene productos con stock bajo
    /// </summary>
    public async Task<Result<List<ProductoDTO>>> ObtenerConStockBajoAsync()
    {
        try
        {
            var productos = await _unitOfWork.Productos.GetProductosStockBajoAsync();
            
            var productosDto = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria?.Nombre ?? "Sin categoría",
                PrecioUnitario = p.PrecioUnitario,
                CostoUnitario = p.CostoUnitario,
                StockActual = p.Stock?.CantidadActual ?? 0,
                StockMinimo = p.Stock?.CantidadReorden ?? 0
            }).ToList();

            return Result<List<ProductoDTO>>.Success(productosDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.ObtenerConStockBajoAsync");
            return Result<List<ProductoDTO>>.Failure($"Error al obtener productos con stock bajo: {ex.Message}");
        }
    }

    /// <summary>
    /// Busca productos por nombre, código o descripción
    /// </summary>
    public async Task<Result<List<ProductoDTO>>> BuscarAsync(string termino)
    {
        try
        {
            var productos = await _unitOfWork.Productos.BuscarPorNombreAsync(termino);
            
            var productosDto = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria?.Nombre ?? "Sin categoría",
                PrecioUnitario = p.PrecioUnitario,
                CostoUnitario = p.CostoUnitario,
                StockActual = p.Stock?.CantidadActual ?? 0,
                StockMinimo = p.Stock?.CantidadReorden ?? 0
            }).ToList();

            return Result<List<ProductoDTO>>.Success(productosDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.BuscarAsync");
            return Result<List<ProductoDTO>>.Failure($"Error al buscar productos: {ex.Message}");
        }
    }

    /// <summary>
    /// Crea un nuevo producto con su stock inicial
    /// </summary>
    public async Task<Result<int>> CrearAsync(ProductoDTO productoDto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            // Validaciones
            var validacion = ValidarProducto(productoDto);
            if (!validacion.IsSuccess)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.Failure(validacion.Message);
            }

            // Verificar código duplicado
            var existe = await _unitOfWork.Productos.AnyAsync(p => 
                p.Codigo == productoDto.Codigo && p.Activo);
            
            if (existe)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.Failure($"Ya existe un producto con el código {productoDto.Codigo}");
            }

            // Crear producto
            var producto = new Producto
            {
                Codigo = productoDto.Codigo.Trim().ToUpper(),
                Nombre = productoDto.Nombre.Trim(),
                Descripcion = productoDto.Descripcion?.Trim(),
                CategoriaId = productoDto.CategoriaId,
                PrecioUnitario = productoDto.PrecioUnitario,
                CostoUnitario = productoDto.CostoUnitario,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.SaveChangesAsync();

            // Crear stock inicial
            var stock = new Stock
            {
                ProductoId = producto.Id,
                CantidadActual = productoDto.StockActual,
                CantidadReorden = productoDto.StockMinimo,
                FechaUltimoIngreso = DateTime.Now,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Stocks.AddAsync(stock);
            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Producto creado: {producto.Nombre} (Código: {producto.Codigo})",
                BLL.Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result<int>.Success(producto.Id, "Producto creado exitosamente");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.CrearAsync");
            return Result<int>.Failure($"Error al crear producto: {ex.Message}");
        }
    }

    /// <summary>
    /// Actualiza un producto existente
    /// </summary>
    public async Task<Result> ActualizarAsync(ProductoDTO productoDto)
    {
        try
        {
            // Validaciones
            var validacion = ValidarProducto(productoDto);
            if (!validacion.IsSuccess)
                return validacion;

            var producto = await _unitOfWork.Productos.GetByIdAsync(productoDto.Id);
            
            if (producto == null)
                return Result.Failure("Producto no encontrado");

            // Verificar código duplicado (excepto el mismo producto)
            var existe = await _unitOfWork.Productos.AnyAsync(p => 
                p.Codigo == productoDto.Codigo && 
                p.Id != productoDto.Id && 
                p.Activo);
            
            if (existe)
                return Result.Failure($"Ya existe otro producto con el código {productoDto.Codigo}");

            // Actualizar producto
            producto.Codigo = productoDto.Codigo.Trim().ToUpper();
            producto.Nombre = productoDto.Nombre.Trim();
            producto.Descripcion = productoDto.Descripcion?.Trim();
            producto.CategoriaId = productoDto.CategoriaId;
            producto.PrecioUnitario = productoDto.PrecioUnitario;
            producto.CostoUnitario = productoDto.CostoUnitario;
            producto.FechaModificacion = DateTime.Now;

            _unitOfWork.Productos.Update(producto);

            // Actualizar stock mínimo
            if (producto.Stock != null)
            {
                producto.Stock.CantidadReorden = productoDto.StockMinimo;
                producto.Stock.FechaModificacion = DateTime.Now;
                _unitOfWork.Stocks.Update(producto.Stock);
            }

            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Producto actualizado: {producto.Nombre} (ID: {producto.Id})",
                BLL.Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result.Success("Producto actualizado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.ActualizarAsync");
            return Result.Failure($"Error al actualizar producto: {ex.Message}");
        }
    }

    /// <summary>
    /// Elimina un producto (soft delete)
    /// </summary>
    public async Task<Result> EliminarAsync(int id)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            
            if (producto == null)
                return Result.Failure("Producto no encontrado");

            // Verificar si tiene movimientos
            var tieneMovimientos = await _unitOfWork.EntradasStock.AnyAsync(e => e.ProductoId == id) ||
                                  await _unitOfWork.DetallesVenta.AnyAsync(d => d.ProductoId == id);
            
            if (tieneMovimientos)
                return Result.Failure("No se puede eliminar el producto porque tiene movimientos registrados");

            _unitOfWork.Productos.Remove(producto);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Media,
                $"Producto eliminado: {producto.Nombre} (ID: {id})",
                BLL.Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result.Success("Producto eliminado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.EliminarAsync");
            return Result.Failure($"Error al eliminar producto: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene todas las categorías
    /// </summary>
    public async Task<Result<List<CategoriaDTO>>> ObtenerCategoriasAsync()
    {
        try
        {
            var categorias = await _unitOfWork.Categorias.GetAllActiveAsync();
            
            var categoriasDto = categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                CantidadProductos = c.Productos?.Count ?? 0
            }).ToList();

            return Result<List<CategoriaDTO>>.Success(categoriasDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ProductoService.ObtenerCategoriasAsync");
            return Result<List<CategoriaDTO>>.Failure($"Error al obtener categorías: {ex.Message}");
        }
    }

    private Result ValidarProducto(ProductoDTO producto)
    {
        var errores = new List<string>();

        if (string.IsNullOrWhiteSpace(producto.Codigo))
            errores.Add("El código es requerido");

        if (string.IsNullOrWhiteSpace(producto.Nombre))
            errores.Add("El nombre es requerido");

        if (producto.CategoriaId <= 0)
            errores.Add("Debe seleccionar una categoría");

        if (producto.PrecioUnitario <= 0)
            errores.Add("El precio debe ser mayor a 0");

        if (producto.CostoUnitario <= 0)
            errores.Add("El costo debe ser mayor a 0");

        if (producto.CostoUnitario > producto.PrecioUnitario)
            errores.Add("El costo no puede ser mayor al precio de venta");

        if (producto.Codigo?.Length > 50)
            errores.Add("El código no puede superar los 50 caracteres");

        if (producto.Nombre?.Length > 200)
            errores.Add("El nombre no puede superar los 200 caracteres");

        if (errores.Any())
            return Result.Failure(errores);

        return Result.Success();
    }
}
