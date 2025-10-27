namespace StockManager.Domain.Enums;

/// <summary>
/// Estados posibles de un cliente
/// </summary>
public enum EstadoCliente
{
    /// <summary>
    /// Cliente activo, puede realizar operaciones
    /// </summary>
    Activo = 1,
    
    /// <summary>
    /// Cliente inactivo, no puede realizar operaciones
    /// </summary>
    Inactivo = 2,
    
    /// <summary>
    /// Cliente suspendido temporalmente
    /// </summary>
    Suspendido = 3
}
