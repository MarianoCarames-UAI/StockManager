namespace StockManager.BLL.DTOs;

/// <summary>
/// DTO para login de usuario
/// </summary>
public class LoginDTO
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
