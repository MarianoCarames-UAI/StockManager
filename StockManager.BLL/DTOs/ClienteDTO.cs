namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para Cliente
/// </summary>
public class ClienteDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public int TipoDocumento { get; set; }
    public string TipoDocumentoNombre { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public int Estado { get; set; }
    public string EstadoNombre { get; set; } = string.Empty;
    public string NombreCompleto => $"{Nombre} {Apellido}";
    public DateTime FechaAlta { get; set; }
}
