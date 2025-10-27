namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para el usuario autenticado
/// </summary>
public class EmpleadoDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int RolId { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public string NombreCompleto => $"{Nombre} {Apellido}";
}
