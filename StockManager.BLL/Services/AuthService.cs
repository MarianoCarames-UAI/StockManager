using Microsoft.EntityFrameworkCore;
using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.DAL.UnitOfWork;
using StockManager.Domain.Enums;
using StockManager.Services.Facade;

namespace StockManager.BLL.Services;

/// <summary>
/// Servicio de autenticaci�n de usuarios
/// </summary>
public class AuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ServicesFacade _services;

    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _services = ServicesFacade.Instance;
    }

    /// <summary>
    /// Autentica un usuario con email y contrase�a
    /// </summary>
    public async Task<Result<EmpleadoDTO>> LoginAsync(LoginDTO loginDto)
    {
        try
        {
            // Validar datos de entrada
            if (string.IsNullOrWhiteSpace(loginDto.Email))
            {
                return Result<EmpleadoDTO>.Failure("El email es requerido");
            }

            if (string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return Result<EmpleadoDTO>.Failure("La contrase�a es requerida");
            }

            // Buscar empleado por email
            var empleado = await _unitOfWork.Empleados
                .SingleOrDefaultAsync(e => e.Email == loginDto.Email && e.Activo);

            if (empleado == null)
            {
                await _services.Bitacora.LogAsync(
                    TipoLog.Usuario,
                    Severidad.Media,
                    $"Intento de login fallido: email no encontrado '{loginDto.Email}'",
                    loginDto.Email
                );

                return Result<EmpleadoDTO>.Failure("Email o contrase�a incorrectos");
            }

            // Verificar contrase�a
            bool passwordValida = _services.Encryption.VerifyPassword(
                loginDto.Password,
                empleado.PasswordHash
            );

            if (!passwordValida)
            {
                await _services.Bitacora.LogAsync(
                    TipoLog.Usuario,
                    Severidad.Media,
                    $"Intento de login fallido: contrase�a incorrecta para '{empleado.Email}'",
                    empleado.Email
                );

                return Result<EmpleadoDTO>.Failure("Email o contrase�a incorrectos");
            }

            // Cargar rol
            var rol = await _unitOfWork.Roles.GetByIdAsync(empleado.RolId);

            if (rol == null)
            {
                return Result<EmpleadoDTO>.Failure("Error al cargar el rol del usuario");
            }

            // Crear DTO de respuesta
            var empleadoDto = new EmpleadoDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Email = empleado.Email,
                RolId = empleado.RolId,
                RolNombre = rol.Nombre
            };

            // Log de login exitoso
            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Login exitoso: {empleado.NombreCompleto} ({rol.Nombre})",
                empleado.Email
            );

            return Result<EmpleadoDTO>.Success(
                empleadoDto,
                $"Bienvenido {empleado.NombreCompleto}"
            );
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, loginDto.Email, "AuthService.LoginAsync");
            return Result<EmpleadoDTO>.Failure($"Error al intentar iniciar sesi�n: {ex.Message}");
        }
    }

    /// <summary>
    /// Registra un logout del usuario
    /// </summary>
    public async Task LogoutAsync(string email)
    {
        await _services.Bitacora.LogAsync(
            TipoLog.Usuario,
            Severidad.Baja,
            $"Logout: {email}",
            email
        );
    }

    /// <summary>
    /// Cambia la contrase�a de un usuario
    /// </summary>
    public async Task<Result> CambiarPasswordAsync(int empleadoId, string passwordActual, string passwordNueva)
    {
        try
        {
            var empleado = await _unitOfWork.Empleados.GetByIdAsync(empleadoId);

            if (empleado == null)
            {
                return Result.Failure("Empleado no encontrado");
            }

            // Verificar contrase�a actual
            if (!_services.Encryption.VerifyPassword(passwordActual, empleado.PasswordHash))
            {
                return Result.Failure("La contrase�a actual es incorrecta");
            }

            // Validar nueva contrase�a
            if (passwordNueva.Length < _services.Settings.PasswordMinLength)
            {
                return Result.Failure($"La contrase�a debe tener al menos {_services.Settings.PasswordMinLength} caracteres");
            }

            // Generar nuevo hash
            empleado.PasswordHash = _services.Encryption.HashPassword(passwordNueva);
            empleado.FechaModificacion = DateTime.Now;

            _unitOfWork.Empleados.Update(empleado);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Cambio de contrase�a: {empleado.Email}",
                empleado.Email
            );

            return Result.Success("Contrase�a actualizada correctamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "AuthService.CambiarPasswordAsync");
            return Result.Failure($"Error al cambiar contrase�a: {ex.Message}");
        }
    }
}
