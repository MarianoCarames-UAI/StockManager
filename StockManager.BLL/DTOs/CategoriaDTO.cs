namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para Categor�a
/// </summary>
public class CategoriaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int CantidadProductos { get; set; }
}
