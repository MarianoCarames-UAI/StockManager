namespace StockManager.Domain.Enums;

/// <summary>
/// Tipos de movimiento de stock
/// </summary>
public enum TipoMovimientoStock
{
    /// <summary>
    /// Entrada de mercadería (compra a proveedor)
    /// </summary>
    Entrada = 1,
    
    /// <summary>
    /// Salida por venta
    /// </summary>
    SalidaVenta = 2,
    
    /// <summary>
    /// Salida manual (merma, robo, donación, etc.)
    /// </summary>
    SalidaManual = 3,
    
    /// <summary>
    /// Ajuste de inventario
    /// </summary>
    Ajuste = 4
}
