using StockManager.BLL.DTOs;

namespace StockManager.BLL.Session;

/// <summary>
/// Administrador de sesi�n de usuario (Singleton)
/// Mantiene el usuario actualmente autenticado
/// </summary>
public sealed class SessionManager
{
    private static readonly Lazy<SessionManager> _instance = 
        new(() => new SessionManager());

    public static SessionManager Instance => _instance.Value;

    private EmpleadoDTO? _currentUser;

    private SessionManager() { }

    /// <summary>
    /// Usuario actualmente autenticado
    /// </summary>
    public EmpleadoDTO? CurrentUser => _currentUser;

    /// <summary>
    /// Indica si hay un usuario autenticado
    /// </summary>
    public bool IsAuthenticated => _currentUser != null;

    /// <summary>
    /// Inicia sesi�n con un usuario
    /// </summary>
    public void Login(EmpleadoDTO usuario)
    {
        _currentUser = usuario ?? throw new ArgumentNullException(nameof(usuario));
    }

    /// <summary>
    /// Cierra la sesi�n actual
    /// </summary>
    public void Logout()
    {
        _currentUser = null;
    }

    /// <summary>
    /// Verifica si el usuario actual tiene un rol espec�fico
    /// </summary>
    public bool TieneRol(string nombreRol)
    {
        return IsAuthenticated && 
               _currentUser!.RolNombre.Equals(nombreRol, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Verifica si el usuario actual es administrador
    /// </summary>
    public bool IsAdmin => TieneRol("Administrador");

    /// <summary>
    /// Verifica si el usuario actual es administrador de ventas
    /// </summary>
    public bool IsAdminVentas => TieneRol("Administrador de Ventas");

    /// <summary>
    /// Verifica si el usuario actual es administrador de dep�sito
    /// </summary>
    public bool IsAdminDeposito => TieneRol("Administrador de Dep�sito");

    /// <summary>
    /// Obtiene el nombre completo del usuario actual
    /// </summary>
    public string GetNombreUsuario()
    {
        return IsAuthenticated ? _currentUser!.NombreCompleto : "Usuario no autenticado";
    }

    /// <summary>
    /// Obtiene el email del usuario actual
    /// </summary>
    public string GetEmailUsuario()
    {
        return IsAuthenticated ? _currentUser!.Email : string.Empty;
    }
}
