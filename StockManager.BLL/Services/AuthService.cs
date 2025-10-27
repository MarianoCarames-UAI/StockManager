using Microsoft.EntityFrameworkCore;
using StockManager.BLL.Common;
using StockManager.BLL.DTOs;
using StockManager.DAL.UnitOfWork;
using StockManager.Domain.Enums;
using StockManager.Services.Facade;

namespace StockManager.BLL.Services;

/// <summary>
/// Servicio de autenticación de usuarios
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
    /// Autentica un usuario con email y contraseña
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
                return Result<EmpleadoDTO>.Failure("La contraseña es requerida");
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

                return Result<EmpleadoDTO>.Failure("Email o contraseña incorrectos");
            }

            // Verificar contraseña
            bool passwordValida = _services.Encryption.VerifyPassword(
                loginDto.Password,
                empleado.PasswordHash
            );

            if (!passwordValida)
            {
                await _services.Bitacora.LogAsync(
                    TipoLog.Usuario,
                    Severidad.Media,
                    $"Intento de login fallido: contraseña incorrecta para '{empleado.Email}'",
                    empleado.Email
                );

                return Result<EmpleadoDTO>.Failure("Email o contraseña incorrectos");
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
            return Result<EmpleadoDTO>.Failure($"Error al intentar iniciar sesión: {ex.Message}");
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
    /// Cambia la contraseña de un usuario
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

            // Verificar contraseña actual
            if (!_services.Encryption.VerifyPassword(passwordActual, empleado.PasswordHash))
            {
                return Result.Failure("La contraseña actual es incorrecta");
            }

            // Validar nueva contraseña
            if (passwordNueva.Length < _services.Settings.PasswordMinLength)
            {
                return Result.Failure($"La contraseña debe tener al menos {_services.Settings.PasswordMinLength} caracteres");
            }

            // Generar nuevo hash
            empleado.PasswordHash = _services.Encryption.HashPassword(passwordNueva);
            empleado.FechaModificacion = DateTime.Now;

            _unitOfWork.Empleados.Update(empleado);
            await _unitOfWork.SaveChangesAsync();

            await _services.Bitacora.LogAsync(
                TipoLog.Usuario,
                Severidad.Baja,
                $"Cambio de contraseña: {empleado.Email}",
                empleado.Email
            );

            return Result.Success("Contraseña actualizada correctamente");
        }
        catch (Exception ex)
        {
            await _services.Bitacora.LogExceptionAsync(ex, null, "AuthService.CambiarPasswordAsync");
            return Result.Failure($"Error al cambiar contraseña: {ex.Message}");
        }
    }
}
