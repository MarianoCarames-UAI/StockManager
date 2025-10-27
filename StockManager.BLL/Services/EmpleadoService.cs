using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.DAL.UnitOfWork;
using StockManager.Domain.Entities;
using StockManager.Domain.Enums;
using StockManager.Services.Facade;
using StockManager.Services.Security;

namespace StockManager.BLL.Services;

public class EmpleadoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ServicesFacade _services;
    private readonly IEncryptionStrategy _encryptionStrategy;

    public EmpleadoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _services = ServicesFacade.Instance;
        _encryptionStrategy = new BCryptStrategy();
    }

    public async Task<Result<List<EmpleadoDTO>>> ObtenerTodosAsync()
    {
        try
        {
            var empleados = await _unitOfWork.Empleados.GetAllActiveAsync();
            var empleadosDto = empleados.Select(e => new EmpleadoDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Email = e.Email,
                RolId = e.RolId,
                RolNombre = e.Rol?.Nombre ?? "Sin rol"
            }).ToList();
            return Result<List<EmpleadoDTO>>.Success(empleadosDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "EmpleadoService.ObtenerTodosAsync");
            return Result<List<EmpleadoDTO>>.Failure($"Error al obtener empleados: {ex.Message}");
        }
    }

    public async Task<Result<EmpleadoDTO>> ObtenerPorIdAsync(int id)
    {
        try
        {
            var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (empleado == null)
                return Result<EmpleadoDTO>.Failure("Empleado no encontrado");

            var empleadoDto = new EmpleadoDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Email = empleado.Email,
                RolId = empleado.RolId,
                RolNombre = empleado.Rol?.Nombre ?? "Sin rol"
            };
            return Result<EmpleadoDTO>.Success(empleadoDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "EmpleadoService.ObtenerPorIdAsync");
            return Result<EmpleadoDTO>.Failure($"Error al obtener empleado: {ex.Message}");
        }
    }

    public async Task<Result<int>> CrearAsync(string nombre, string apellido, string email, int rolId, string password)
    {
        try
        {
            var validacion = ValidarEmpleado(nombre, apellido, email, rolId, password);
            if (!validacion.IsSuccess)
                return Result<int>.Failure(validacion.Message);

            var empleadoExistente = (await _unitOfWork.Empleados.GetAllActiveAsync())
                .FirstOrDefault(e => e.Email.ToLower() == email.Trim().ToLower());
            
            if (empleadoExistente != null)
                return Result<int>.Failure($"Ya existe un empleado con el email '{email}'");

            // Hashear password
            var passwordHash = _encryptionStrategy.HashPassword(password);

            var empleado = new Empleado
            {
                Nombre = nombre.Trim(),
                Apellido = apellido.Trim(),
                Email = email.Trim().ToLower(),
                RolId = rolId,
                PasswordHash = passwordHash,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Empleados.AddAsync(empleado);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(TipoLog.Usuario, Severidad.Media,
                $"Empleado creado: {empleado.NombreCompleto} (Email: {empleado.Email})", email);

            return Result<int>.Success(empleado.Id, "Empleado creado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "EmpleadoService.CrearAsync");
            return Result<int>.Failure($"Error al crear empleado: {ex.Message}");
        }
    }

    public async Task<Result> ActualizarAsync(int id, string nombre, string apellido, string email, int rolId)
    {
        try
        {
            var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (empleado == null)
                return Result.Failure("Empleado no encontrado");

            var validacion = ValidarEmpleado(nombre, apellido, email, rolId, null);
            if (!validacion.IsSuccess)
                return validacion;

            var empleadoExistente = (await _unitOfWork.Empleados.GetAllActiveAsync())
                .FirstOrDefault(e => e.Email.ToLower() == email.Trim().ToLower() && e.Id != id);
            
            if (empleadoExistente != null)
                return Result.Failure($"Ya existe otro empleado con el email '{email}'");

            empleado.Nombre = nombre.Trim();
            empleado.Apellido = apellido.Trim();
            empleado.Email = email.Trim().ToLower();
            empleado.RolId = rolId;
            empleado.FechaModificacion = DateTime.Now;

            _unitOfWork.Empleados.Update(empleado);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(TipoLog.Usuario, Severidad.Media,
                $"Empleado actualizado: {empleado.NombreCompleto}", email);

            return Result.Success("Empleado actualizado exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "EmpleadoService.ActualizarAsync");
            return Result.Failure($"Error al actualizar empleado: {ex.Message}");
        }
    }

    public async Task<Result> CambiarPasswordAsync(int id, string nuevoPassword)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nuevoPassword))
                return Result.Failure("La contraseña no puede estar vacía");
            if (nuevoPassword.Length < 6)
                return Result.Failure("La contraseña debe tener al menos 6 caracteres");

            var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (empleado == null)
                return Result.Failure("Empleado no encontrado");

            // Hashear nuevo password
            empleado.PasswordHash = _encryptionStrategy.HashPassword(nuevoPassword);
            empleado.FechaModificacion = DateTime.Now;

            _unitOfWork.Empleados.Update(empleado);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(TipoLog.Usuario, Severidad.Media,
                $"Password cambiado para empleado: {empleado.NombreCompleto}", empleado.Email);

            return Result.Success("Contraseña actualizada exitosamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "EmpleadoService.CambiarPasswordAsync");
            return Result.Failure($"Error al cambiar contraseña: {ex.Message}");
        }
    }

    public async Task<Result<List<RolDTO>>> ObtenerRolesAsync()
    {
        try
        {
            var roles = await _unitOfWork.Roles.GetAllActiveAsync();
            var rolesDto = roles.Select(r => new RolDTO
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion
            }).ToList();
            return Result<List<RolDTO>>.Success(rolesDto);
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "EmpleadoService.ObtenerRolesAsync");
            return Result<List<RolDTO>>.Failure($"Error al obtener roles: {ex.Message}");
        }
    }

    private Result ValidarEmpleado(string nombre, string apellido, string email, int rolId, string? password)
    {
        var errores = new List<string>();

        if (string.IsNullOrWhiteSpace(nombre))
            errores.Add("El nombre es requerido");
        else if (nombre.Length < 2)
            errores.Add("El nombre debe tener al menos 2 caracteres");

        if (string.IsNullOrWhiteSpace(apellido))
            errores.Add("El apellido es requerido");
        else if (apellido.Length < 2)
            errores.Add("El apellido debe tener al menos 2 caracteres");

        if (string.IsNullOrWhiteSpace(email))
            errores.Add("El email es requerido");
        else if (!email.Contains("@") || !email.Contains("."))
            errores.Add("El formato del email es inválido");

        if (rolId <= 0)
            errores.Add("Debe seleccionar un rol");

        if (password != null)
        {
            if (string.IsNullOrWhiteSpace(password))
                errores.Add("La contraseña es requerida");
            else if (password.Length < 6)
                errores.Add("La contraseña debe tener al menos 6 caracteres");
        }

        return errores.Any() ? Result.Failure(errores) : Result.Success();
    }
}