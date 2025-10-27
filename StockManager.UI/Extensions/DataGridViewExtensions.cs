namespace StockManager.UI.Extensions
{
    /// <summary>
    /// Extension methods para configurar DataGridView
    /// </summary>
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Establece la visibilidad de una columna
        /// </summary>
        public static void SetVisibility(this DataGridViewColumn? column, bool visible)
        {
            try
            {
                if (column != null)
                    column.Visible = visible;
            }
            catch
            {
                // Ignorar silenciosamente cualquier error
            }
        }

        /// <summary>
        /// Establece el encabezado y opcionalmente el ancho de una columna
        /// </summary>
        public static void SetHeader(this DataGridViewColumn? column, string? headerText, int? width = null)
        {
            try
            {
                if (column == null)
                    return;

                column.HeaderText = headerText ?? string.Empty;
                
                if (width.HasValue && width.Value > 0)
                {
                    column.Width = width.Value;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
            }
            catch
            {
                // Ignorar silenciosamente cualquier error
            }
        }
    }
}
