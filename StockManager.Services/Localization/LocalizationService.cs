namespace StockManager.Services.Localization;

/// <summary>
/// Servicio para gestión de idiomas y traducciones
/// Patrón Singleton
/// </summary>
public class LocalizationService
{
    private static LocalizationService? _instance;
    private static readonly object _lock = new object();
    
    private string _currentLanguage;
    private readonly Dictionary<string, Dictionary<string, string>> _translations;

    private LocalizationService()
    {
        _currentLanguage = "es-AR"; // Español por defecto
        _translations = new Dictionary<string, Dictionary<string, string>>();
        InitializeTranslations();
    }

    public static LocalizationService Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LocalizationService();
                    }
                }
            }
            return _instance;
        }
    }

    public string CurrentLanguage => _currentLanguage;

    public void SetLanguage(string language)
    {
        if (_translations.ContainsKey(language))
        {
            _currentLanguage = language;
            OnLanguageChanged?.Invoke(this, language);
        }
    }

    public event EventHandler<string>? OnLanguageChanged;

    public string GetString(string key)
    {
        if (_translations.TryGetValue(_currentLanguage, out var languageDict))
        {
            if (languageDict.TryGetValue(key, out var translation))
            {
                return translation;
            }
        }
        return key; // Si no encuentra traducción, devuelve la clave
    }

    private void InitializeTranslations()
    {
        // ESPAÑOL
        var spanish = new Dictionary<string, string>
        {
            // Login
            ["Login_Title"] = "Stock Manager - Iniciar Sesión",
            ["Login_Email"] = "Email:",
            ["Login_Password"] = "Contraseña:",
            ["Login_Login"] = "Iniciar Sesión",
            ["Login_Exit"] = "Salir",
            ["Login_SelectLanguage"] = "Idioma:",
            ["Login_Error"] = "Error de autenticación",
            ["Login_InvalidCredentials"] = "Email o contraseña incorrectos",
            
            // Main Menu
            ["Menu_Sales"] = "Ventas",
            ["Menu_Clients"] = "Clientes",
            ["Menu_Products"] = "Productos",
            ["Menu_Stock"] = "Stock",
            ["Menu_Reports"] = "Reportes",
            ["Menu_Admin"] = "Admin",
            ["Menu_Logout"] = "Cerrar Sesión",
            ["Menu_Exit"] = "Salir",
            ["Menu_Language"] = "Idioma",
            
            // Common
            ["Common_New"] = "Nuevo",
            ["Common_Edit"] = "Editar",
            ["Common_Delete"] = "Eliminar",
            ["Common_Search"] = "Buscar",
            ["Common_Save"] = "Guardar",
            ["Common_Cancel"] = "Cancelar",
            ["Common_Close"] = "Cerrar",
            ["Common_Yes"] = "Sí",
            ["Common_No"] = "No",
            ["Common_OK"] = "Aceptar",
            ["Common_Error"] = "Error",
            ["Common_Success"] = "Éxito",
            ["Common_Warning"] = "Advertencia",
            ["Common_Information"] = "Información",
            ["Common_Confirmation"] = "Confirmación",
            
            // Clients
            ["Clients_Title"] = "Gestión de Clientes",
            ["Clients_NewClient"] = "Nuevo Cliente",
            ["Clients_EditClient"] = "Editar Cliente",
            ["Clients_Name"] = "Nombre",
            ["Clients_Lastname"] = "Apellido",
            ["Clients_Document"] = "Documento",
            ["Clients_Email"] = "Email",
            ["Clients_Phone"] = "Teléfono",
            ["Clients_Address"] = "Dirección",
            ["Clients_Delete"] = "Eliminar Cliente",
            ["Clients_Search"] = "Buscar cliente...",
            
            // Products
            ["Products_Title"] = "Gestión de Productos",
            ["Products_NewProduct"] = "Nuevo Producto",
            ["Products_Code"] = "Código",
            ["Products_Name"] = "Nombre",
            ["Products_Description"] = "Descripción",
            ["Products_Category"] = "Categoría",
            ["Products_Price"] = "Precio",
            ["Products_Cost"] = "Costo",
            ["Products_Stock"] = "Stock",
            ["Products_MinStock"] = "Stock Mínimo",
            
            // Stock
            ["Stock_Title"] = "Gestión de Stock",
            ["Stock_CurrentStock"] = "Stock Actual",
            ["Stock_MinStock"] = "Stock Mínimo",
            ["Stock_Entry"] = "Entrada",
            ["Stock_Exit"] = "Salida",
            ["Stock_Quantity"] = "Cantidad",
            ["Stock_Edit"] = "Editar Stock",
            ["Stock_Product"] = "Producto",
            
            // Sales
            ["Sales_Title"] = "Nueva Venta",
            ["Sales_List"] = "Lista de Ventas",
            ["Sales_Date"] = "Fecha",
            ["Sales_Client"] = "Cliente",
            ["Sales_Product"] = "Producto",
            ["Sales_Quantity"] = "Cantidad",
            ["Sales_UnitPrice"] = "Precio Unitario",
            ["Sales_Subtotal"] = "Subtotal",
            ["Sales_Total"] = "Total",
            ["Sales_AddProduct"] = "Agregar Producto",
            ["Sales_RemoveProduct"] = "Quitar",
            ["Sales_CompleteSale"] = "Completar Venta",
            
            // Reports
            ["Reports_Title"] = "Reportes",
            ["Reports_Sales"] = "Ventas",
            ["Reports_Products"] = "Productos",
            ["Reports_Clients"] = "Clientes",
            ["Reports_From"] = "Desde",
            ["Reports_To"] = "Hasta",
            ["Reports_Search"] = "Buscar",
            ["Reports_Export"] = "Exportar",
            ["Reports_TopProducts"] = "Top Productos",
            ["Reports_ActiveClients"] = "Clientes Activos",
            
            // Admin
            ["Admin_Title"] = "Panel de Administración",
            ["Admin_Users"] = "Usuarios",
            ["Admin_Roles"] = "Roles",
            ["Admin_System"] = "Sistema",
            ["Admin_NewUser"] = "Nuevo Usuario",
            ["Admin_EditUser"] = "Editar Usuario",
            ["Admin_ChangePassword"] = "Cambiar Contraseña",
            ["Admin_ViewLogs"] = "Ver Logs",
            ["Admin_CleanLogs"] = "Limpiar Logs",
            ["Admin_Backup"] = "Backup",
            ["Admin_User"] = "Usuario",
            ["Admin_Role"] = "Rol",
            ["Admin_CreatedDate"] = "Fecha Alta",
            ["Admin_Email"] = "Email",
            ["Admin_Password"] = "Contraseña",
            ["Admin_ConfirmPassword"] = "Confirmar Contraseña",
            ["Admin_Save"] = "Guardar Usuario",
            ["Admin_Delete"] = "Eliminar Usuario",
            ["Admin_Search"] = "Buscar usuario...",
            
            // Messages
            ["Msg_SaveSuccess"] = "Guardado exitosamente",
            ["Msg_DeleteConfirm"] = "¿Está seguro que desea eliminar este registro?",
            ["Msg_DeleteSuccess"] = "Eliminado exitosamente",
            ["Msg_LoadError"] = "Error al cargar datos",
            ["Msg_SaveError"] = "Error al guardar",
            ["Msg_NoSelection"] = "Debe seleccionar un registro",
            ["Msg_LogoutConfirm"] = "¿Desea cerrar sesión?",
            ["Msg_ExitConfirm"] = "¿Está seguro que desea salir de la aplicación?",

        };

        // INGLÉS
        var english = new Dictionary<string, string>
        {
            // Login
            ["Login_Title"] = "Stock Manager - Sign In",
            ["Login_Email"] = "Email:",
            ["Login_Password"] = "Password:",
            ["Login_Login"] = "Sign In",
            ["Login_Exit"] = "Exit",
            ["Login_SelectLanguage"] = "Language:",
            ["Login_Error"] = "Authentication Error",
            ["Login_InvalidCredentials"] = "Invalid email or password",
            
            // Main Menu
            ["Menu_Sales"] = "Sales",
            ["Menu_Clients"] = "Clients",
            ["Menu_Products"] = "Products",
            ["Menu_Stock"] = "Stock",
            ["Menu_Reports"] = "Reports",
            ["Menu_Admin"] = "Admin",
            ["Menu_Logout"] = "Logout",
            ["Menu_Exit"] = "Exit",
            ["Menu_Language"] = "Language",
            
            // Common
            ["Common_New"] = "New",
            ["Common_Edit"] = "Edit",
            ["Common_Delete"] = "Delete",
            ["Common_Search"] = "Search",
            ["Common_Save"] = "Save",
            ["Common_Cancel"] = "Cancel",
            ["Common_Close"] = "Close",
            ["Common_Yes"] = "Yes",
            ["Common_No"] = "No",
            ["Common_OK"] = "OK",
            ["Common_Error"] = "Error",
            ["Common_Success"] = "Success",
            ["Common_Warning"] = "Warning",
            ["Common_Information"] = "Information",
            ["Common_Confirmation"] = "Confirmation",
            
            // Clients
            ["Clients_Title"] = "Client Management",
            ["Clients_NewClient"] = "New Client",
            ["Clients_EditClient"] = "Edit Client",
            ["Clients_Name"] = "Name",
            ["Clients_Lastname"] = "Last Name",
            ["Clients_Document"] = "Document",
            ["Clients_Email"] = "Email",
            ["Clients_Phone"] = "Phone",
            ["Clients_Address"] = "Address",
            ["Clients_Delete"] = "Delete Client",
            ["Clients_Search"] = "Search client...",
            
            // Products
            ["Products_Title"] = "Product Management",
            ["Products_NewProduct"] = "New Product",
            ["Products_Code"] = "Code",
            ["Products_Name"] = "Name",
            ["Products_Description"] = "Description",
            ["Products_Category"] = "Category",
            ["Products_Price"] = "Price",
            ["Products_Cost"] = "Cost",
            ["Products_Stock"] = "Stock",
            ["Products_MinStock"] = "Min Stock",
            
            // Stock
            ["Stock_Title"] = "Stock Management",
            ["Stock_CurrentStock"] = "Current Stock",
            ["Stock_MinStock"] = "Minimum Stock",
            ["Stock_Entry"] = "Entry",
            ["Stock_Exit"] = "Exit",
            ["Stock_Quantity"] = "Quantity",
            
            // Sales
            ["Sales_Title"] = "New Sale",
            ["Sales_Date"] = "Date",
            ["Sales_Client"] = "Client",
            ["Sales_Product"] = "Product",
            ["Sales_Quantity"] = "Quantity",
            ["Sales_UnitPrice"] = "Unit Price",
            ["Sales_Subtotal"] = "Subtotal",
            ["Sales_Total"] = "Total",
            
            // Admin
            ["Admin_Title"] = "Administration Panel",
            ["Admin_Users"] = "Users",
            ["Admin_Roles"] = "Roles",
            ["Admin_System"] = "System",
            ["Admin_NewUser"] = "New User",
            ["Admin_EditUser"] = "Edit User",
            ["Admin_ChangePassword"] = "Change Password",
            
            // Messages
            ["Msg_SaveSuccess"] = "Saved successfully",
            ["Msg_DeleteConfirm"] = "Are you sure you want to delete this record?",
            ["Msg_DeleteSuccess"] = "Deleted successfully",
            ["Msg_LoadError"] = "Error loading data",
            ["Msg_SaveError"] = "Error saving",
            ["Msg_NoSelection"] = "You must select a record",
            ["Msg_LogoutConfirm"] = "Do you want to log out?",
            ["Msg_ExitConfirm"] = "Are you sure you want to exit the application?",

        };

        _translations.Add("es-AR", spanish);
        _translations.Add("en-US", english);
    }

    public List<LanguageInfo> GetAvailableLanguages()
    {
        return new List<LanguageInfo>
        {
            new LanguageInfo("es-AR", "Español"),
            new LanguageInfo("en-US", "English")
        };
    }
}
