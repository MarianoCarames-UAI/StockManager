namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para transferencia de datos de Rol
/// </summary>
public class RolDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
}
