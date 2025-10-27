using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.DAL.UnitOfWork;
using StockManager.Domain.Entities;
using StockManager.Domain.Enums;
using StockManager.Services.Facade;

namespace StockManager.BLL.Services;

/// <summary>
/// Servicio de negocio para gestión de clientes
/// </summary>
public class ClienteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ServicesFacade _services;

    public ClienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _services = ServicesFacade.Instance;
    }

    /// <summary>
    /// Obtiene todos los clientes activos
    /// </summary>
    public async Task<Result<List<ClienteDTO>>> ObtenerTodosAsync()
    {
        try
        {
            var clientes = await _unitOfWork.Clientes.GetAllActiveAsync();
            
            var clientesDto = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                TipoDocumento = (int)c.TipoDocumento,
                TipoDocumentoNombre = c.TipoDocumento.ToString(),
                Documento = c.Documento,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Email = c.Email,
                Estado = (int)c.Estado,
                EstadoNombre = c.Estado.ToString(),
                FechaAlta = c.FechaCreacion
            }).ToList();

            return Result<List<ClienteDTO>>.Success(clientesDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ClienteService.ObtenerTodosAsync");
            return Result<List<ClienteDTO>>.Failure($"Error al obtener clientes: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene un cliente por ID
    /// </summary>
    public async Task<Result<ClienteDTO>> ObtenerPorIdAsync(int id)
    {
        try
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            
            if (cliente == null)
                return Result<ClienteDTO>.Failure("Cliente no encontrado");

            var clienteDto = new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                TipoDocumento = (int)cliente.TipoDocumento,
                TipoDocumentoNombre = cliente.TipoDocumento.ToString(),
                Documento = cliente.Documento,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Estado = (int)cliente.Estado,
                EstadoNombre = cliente.Estado.ToString(),
                FechaAlta = cliente.FechaCreacion
            };

            return Result<ClienteDTO>.Success(clienteDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ClienteService.ObtenerPorIdAsync");
            return Result<ClienteDTO>.Failure($"Error al obtener cliente: {ex.Message}");
        }
    }

    /// <summary>
    /// Busca clientes por nombre, apellido o documento
    /// </summary>
    public async Task<Result<List<ClienteDTO>>> BuscarAsync(string termino)
    {
        try
        {
            var clientes = await _unitOfWork.Clientes.FindAsync(c => 
                c.Activo && 
                (c.Nombre.Contains(termino) || 
                 c.Apellido.Contains(termino) || 
                 c.Documento.Contains(termino)));

            var clientesDto = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                TipoDocumento = (int)c.TipoDocumento,
                TipoDocumentoNombre = c.TipoDocumento.ToString(),
                Documento = c.Documento,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Email = c.Email,
                Estado = (int)c.Estado,
                EstadoNombre = c.Estado.ToString(),
                FechaAlta = c.FechaCreacion
            }).ToList();

            return Result<List<ClienteDTO>>.Success(clientesDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ClienteService.BuscarAsync");
            return Result<List<ClienteDTO>>.Failure($"Error al buscar clientes: {ex.Message}");
        }
    }

    /// <summary>
    /// Crea un nuevo cliente
    /// </summary>
    public async Task<Result<int>> CrearAsync(ClienteDTO clienteDto)
    {
        try
        {
            // Validaciones
            var validacion = ValidarCliente(clienteDto);
            if (!validacion.IsSuccess)
                return Result<int>.Failure(validacion.Message);

            // Verificar documento duplicado
            var existe = await _unitOfWork.Clientes.AnyAsync(c => 
                c.Documento == clienteDto.Documento && c.Activo);
            
            if (existe)
                return Result<int>.Failure($"Ya existe un cliente con el documento {clienteDto.Documento}");

            // Crear entidad
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre.Trim(),
                Apellido = clienteDto.Apellido.Trim(),
                TipoDocumento = (TipoDocumento)clienteDto.TipoDocumento,
                Documento = clienteDto.Documento.Trim(),
                Direccion = clienteDto.Direccion?.Trim(),
                Telefono = clienteDto.Telefono?.Trim(),
                Email = clienteDto.Email?.Trim(),
                Estado = (EstadoCliente)clienteDto.Estado,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Clientes.AddAsync(cliente);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Cliente creado: {cliente.NombreCompleto} (Doc: {cliente.Documento})",
                BLL.Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result<int>.Success(cliente.Id, "Cliente creado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ClienteService.CrearAsync");
            return Result<int>.Failure($"Error al crear cliente: {ex.Message}");
        }
    }

    /// <summary>
    /// Actualiza un cliente existente
    /// </summary>
    public async Task<Result> ActualizarAsync(ClienteDTO clienteDto)
    {
        try
        {
            // Validaciones
            var validacion = ValidarCliente(clienteDto);
            if (!validacion.IsSuccess)
                return validacion;

            var cliente = await _unitOfWork.Clientes.GetByIdAsync(clienteDto.Id);
            
            if (cliente == null)
                return Result.Failure("Cliente no encontrado");

            // Verificar documento duplicado (excepto el mismo cliente)
            var existe = await _unitOfWork.Clientes.AnyAsync(c => 
                c.Documento == clienteDto.Documento && 
                c.Id != clienteDto.Id && 
                c.Activo);
            
            if (existe)
                return Result.Failure($"Ya existe otro cliente con el documento {clienteDto.Documento}");

            // Actualizar datos
            cliente.Nombre = clienteDto.Nombre.Trim();
            cliente.Apellido = clienteDto.Apellido.Trim();
            cliente.TipoDocumento = (TipoDocumento)clienteDto.TipoDocumento;
            cliente.Documento = clienteDto.Documento.Trim();
            cliente.Direccion = clienteDto.Direccion?.Trim();
            cliente.Telefono = clienteDto.Telefono?.Trim();
            cliente.Email = clienteDto.Email?.Trim();
            cliente.Estado = (EstadoCliente)clienteDto.Estado;
            cliente.FechaModificacion = DateTime.Now;

            _unitOfWork.Clientes.Update(cliente);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Cliente actualizado: {cliente.NombreCompleto} (ID: {cliente.Id})",
                BLL.Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result.Success("Cliente actualizado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ClienteService.ActualizarAsync");
            return Result.Failure($"Error al actualizar cliente: {ex.Message}");
        }
    }

    /// <summary>
    /// Elimina un cliente (soft delete)
    /// </summary>
    public async Task<Result> EliminarAsync(int id)
    {
        try
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            
            if (cliente == null)
                return Result.Failure("Cliente no encontrado");

            // Verificar si tiene ventas
            var tieneVentas = await _unitOfWork.Ventas.AnyAsync(v => v.ClienteId == id);
            
            if (tieneVentas)
                return Result.Failure("No se puede eliminar el cliente porque tiene ventas registradas");

            _unitOfWork.Clientes.Remove(cliente);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Media,
                $"Cliente eliminado: {cliente.NombreCompleto} (ID: {id})",
                BLL.Session.SessionManager.Instance.GetEmailUsuario()
            );

            return Result.Success("Cliente eliminado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "ClienteService.EliminarAsync");
            return Result.Failure($"Error al eliminar cliente: {ex.Message}");
        }
    }

    private Result ValidarCliente(ClienteDTO cliente)
    {
        var errores = new List<string>();

        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            errores.Add("El nombre es requerido");

        if (string.IsNullOrWhiteSpace(cliente.Apellido))
            errores.Add("El apellido es requerido");

        if (string.IsNullOrWhiteSpace(cliente.Documento))
            errores.Add("El documento es requerido");

        if (cliente.Nombre?.Length > 100)
            errores.Add("El nombre no puede superar los 100 caracteres");

        if (cliente.Apellido?.Length > 100)
            errores.Add("El apellido no puede superar los 100 caracteres");

        if (cliente.Documento?.Length > 20)
            errores.Add("El documento no puede superar los 20 caracteres");

        if (!string.IsNullOrWhiteSpace(cliente.Email) && !cliente.Email.Contains("@"))
            errores.Add("El email no tiene un formato válido");

        if (errores.Any())
            return Result.Failure(errores);

        return Result.Success();
    }
}
