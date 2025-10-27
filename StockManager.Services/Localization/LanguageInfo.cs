namespace StockManager.Services.Localization;

/// <summary>
/// Clase para representar un idioma disponible
/// </summary>
public class LanguageInfo
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public LanguageInfo() { }

    public LanguageInfo(string code, string name)
    {
        Code = code;
        Name = name;
    }
}
