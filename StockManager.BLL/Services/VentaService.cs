using Microsoft.EntityFrameworkCore;
using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.DAL.UnitOfWork;
using StockManager.Domain.Entities;
using StockManager.Domain.Enums;
using StockManager.Services.Facade;

namespace StockManager.BLL.Services;

/// <summary>
/// Servicio de negocio para gestión de ventas
/// </summary>
public class VentaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ServicesFacade _services;

    public VentaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _services = ServicesFacade.Instance;
    }

    /// <summary>
    /// Obtiene todas las ventas
    /// </summary>
    public async Task<Result<List<VentaDTO>>> ObtenerTodasAsync()
    {
        try
        {
            var ventas = await _unitOfWork.Ventas.GetAllActiveAsync();
            
            var ventasDto = ventas.Select(v => new VentaDTO
            {
                Id = v.Id,
                Fecha = v.Fecha,
                ClienteId = v.ClienteId,
                ClienteNombre = v.Cliente?.NombreCompleto ?? "Sin cliente",
                EmpleadoId = v.EmpleadoId,
                EmpleadoNombre = v.Empleado?.NombreCompleto ?? "Sin empleado",
                Total = v.Total,
                NumeroComprobante = v.NumeroComprobante,
                Observaciones = v.Observaciones
            }).ToList();

            return Result<List<VentaDTO>>.Success(ventasDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "VentaService.ObtenerTodasAsync");
            return Result<List<VentaDTO>>.Failure($"Error al obtener ventas: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene ventas por rango de fechas
    /// </summary>
    public async Task<Result<List<VentaDTO>>> ObtenerPorFechaAsync(DateTime desde, DateTime hasta)
    {
        try
        {
            var ventas = await _unitOfWork.Ventas.GetByFechaRangoAsync(desde, hasta);
            
            var ventasDto = ventas.Select(v => new VentaDTO
            {
                Id = v.Id,
                Fecha = v.Fecha,
                ClienteId = v.ClienteId,
                ClienteNombre = v.Cliente?.NombreCompleto ?? "Sin cliente",
                EmpleadoId = v.EmpleadoId,
                EmpleadoNombre = v.Empleado?.NombreCompleto ?? "Sin empleado",
                Total = v.Total,
                NumeroComprobante = v.NumeroComprobante,
                Observaciones = v.Observaciones
            }).ToList();

            return Result<List<VentaDTO>>.Success(ventasDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "VentaService.ObtenerPorFechaAsync");
            return Result<List<VentaDTO>>.Failure($"Error al obtener ventas: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene una venta con sus detalles
    /// </summary>
    public async Task<Result<VentaDTO>> ObtenerConDetallesAsync(int ventaId)
    {
        try
        {
            var venta = await _unitOfWork.Ventas.GetVentaConDetallesAsync(ventaId);
            
            if (venta == null)
                return Result<VentaDTO>.Failure("Venta no encontrada");

            var ventaDto = new VentaDTO
            {
                Id = venta.Id,
                Fecha = venta.Fecha,
                ClienteId = venta.ClienteId,
                ClienteNombre = venta.Cliente?.NombreCompleto ?? "Sin cliente",
                EmpleadoId = venta.EmpleadoId,
                EmpleadoNombre = venta.Empleado?.NombreCompleto ?? "Sin empleado",
                Total = venta.Total,
                NumeroComprobante = venta.NumeroComprobante,
                Observaciones = venta.Observaciones,
                Detalles = venta.Detalles.Select(d => new DetalleVentaDTO
                {
                    Id = d.Id,
                    VentaId = d.VentaId,
                    ProductoId = d.ProductoId,
                    ProductoCodigo = d.Producto?.Codigo ?? "",
                    ProductoNombre = d.Producto?.Nombre ?? "",
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            };

            return Result<VentaDTO>.Success(ventaDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "VentaService.ObtenerConDetallesAsync");
            return Result<VentaDTO>.Failure($"Error al obtener venta: {ex.Message}");
        }
    }

    /// <summary>
    /// Crea una nueva venta con validación de stock
    /// </summary>
    public async Task<Result<int>> CrearVentaAsync(VentaDTO ventaDto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            // Validaciones
            var validacion = await ValidarVentaAsync(ventaDto);
            if (!validacion.IsSuccess)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.Failure(validacion.Message);
            }

            // Crear venta
            var venta = new Venta
            {
                Fecha = DateTime.Now,
                ClienteId = ventaDto.ClienteId,
                EmpleadoId = ventaDto.EmpleadoId,
                Total = ventaDto.Detalles.Sum(d => d.Subtotal),
                NumeroComprobante = GenerarNumeroComprobante(),
                Observaciones = ventaDto.Observaciones,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Ventas.AddAsync(venta);
            await _unitOfWork.SaveChangesAsync();

            // Crear detalles y actualizar stock
            foreach (var detalleDto in ventaDto.Detalles)
            {
                // Crear detalle
                var detalle = new DetalleVenta
                {
                    VentaId = venta.Id,
                    ProductoId = detalleDto.ProductoId,
                    Cantidad = detalleDto.Cantidad,
                    PrecioUnitario = detalleDto.PrecioUnitario,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };

                await _unitOfWork.DetallesVenta.AddAsync(detalle);

                // Actualizar stock
                var producto = await _unitOfWork.Productos.GetByIdAsync(detalleDto.ProductoId);
                if (producto?.Stock != null)
                {
                    producto.Stock.CantidadActual -= detalleDto.Cantidad;
                    producto.Stock.FechaUltimaSalida = DateTime.Now;
                    producto.Stock.FechaModificacion = DateTime.Now;
                    _unitOfWork.Stocks.Update(producto.Stock);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            // Log
            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Venta creada: {venta.NumeroComprobante} - Cliente: {ventaDto.ClienteNombre} - Total: ${venta.Total:N2}",
                Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result<int>.Success(venta.Id, $"Venta {venta.NumeroComprobante} creada exitosamente");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            await _services.Bitacora.LogExceptionAsync(ex, null, "VentaService.CrearVentaAsync");
            return Result<int>.Failure($"Error al crear venta: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene el total de ventas del día
    /// </summary>
    public async Task<Result<decimal>> ObtenerTotalDelDiaAsync()
    {
        try
        {
            var hoy = DateTime.Today;
            var manana = hoy.AddDays(1);
            
            var total = await _unitOfWork.Ventas.GetTotalVentasPeriodoAsync(hoy, manana);
            
            return Result<decimal>.Success(total, $"Total del día: ${total:N2}");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "VentaService.ObtenerTotalDelDiaAsync");
            return Result<decimal>.Failure($"Error al obtener total: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene productos disponibles para venta
    /// </summary>
    public async Task<Result<List<DetalleVentaDTO>>> ObtenerProductosDisponiblesAsync()
    {
        try
        {
            var productos = await _unitOfWork.Productos.GetAllActiveAsync();
            
            var productosDto = productos
                .Where(p => p.Stock != null && p.Stock.CantidadActual > 0)
                .Select(p => new DetalleVentaDTO
                {
                    ProductoId = p.Id,
                    ProductoCodigo = p.Codigo,
                    ProductoNombre = p.Nombre,
                    PrecioUnitario = p.PrecioUnitario,
                    StockDisponible = p.Stock?.CantidadActual ?? 0,
                    Cantidad = 0
                })
                .OrderBy(p => p.ProductoNombre)
                .ToList();

            return Result<List<DetalleVentaDTO>>.Success(productosDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "VentaService.ObtenerProductosDisponiblesAsync");
            return Result<List<DetalleVentaDTO>>.Failure($"Error al obtener productos: {ex.Message}");
        }
    }

    private async Task<Result> ValidarVentaAsync(VentaDTO venta)
    {
        var errores = new List<string>();

        if (venta.ClienteId <= 0)
            errores.Add("Debe seleccionar un cliente");

        if (venta.EmpleadoId <= 0)
            errores.Add("Debe seleccionar un empleado");

        if (venta.Detalles == null || !venta.Detalles.Any())
            errores.Add("Debe agregar al menos un producto");

        // Validar stock de cada producto
        if (venta.Detalles != null)
        {
            foreach (var detalle in venta.Detalles)
            {
                if (detalle.Cantidad <= 0)
                {
                    errores.Add($"La cantidad del producto {detalle.ProductoNombre} debe ser mayor a 0");
                    continue;
                }

                var producto = await _unitOfWork.Productos.GetByIdAsync(detalle.ProductoId);
                if (producto?.Stock == null)
                {
                    errores.Add($"El producto {detalle.ProductoNombre} no tiene stock configurado");
                    continue;
                }

                if (producto.Stock.CantidadActual < detalle.Cantidad)
                {
                    errores.Add($"Stock insuficiente para {detalle.ProductoNombre}. Disponible: {producto.Stock.CantidadActual}, Solicitado: {detalle.Cantidad}");
                }
            }
        }

        if (errores.Any())
            return Result.Failure(errores);

        return Result.Success();
    }

    private string GenerarNumeroComprobante()
    {
        var fecha = DateTime.Now;
        var random = new Random();
        return $"{fecha:yyyyMMdd}-{random.Next(1000, 9999)}";
    }
}
