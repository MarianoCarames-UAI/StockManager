# ?? MULTI-IDIOMA - CORRECCIONES FINALES NECESARIAS

## ?? PROBLEMAS IDENTIFICADOS Y SOLUCIONES

### 1. MainForm.cs - Nombres de variables incorrectos

**ERROR**: El código usa `menuClientes`, `menuProductos`, etc. pero el Designer tiene `menuItemClientes`, `menuItemProductos`.

**SOLUCIÓN**: En `MainForm.cs` líneas 54-59, reemplazar:
```csharp
// INCORRECTO:
menuClientes.Click += MenuClientes_Click;
menuProductos.Click += MenuProductos_Click;
menuStock.Click += MenuStock_Click;
menuVentas.Click += MenuVentas_Click;
menuReportes.Click += MenuReportes_Click;
menuAdmin.Click += MenuAdmin_Click;

// CORRECTO:
menuItemClientes.Click += menuItemClientes_Click;
menuItemProductos.Click += menuItemProductos_Click;
menuItemStock.Click += menuItemStock_Click;
menuItemVentas.Click += menuItemVentas_Click;
menuItemReportes.Click += menuItemReportes_Click;
menuItemAdmin.Click += menuItemAdmin_Click;
```

### 2. SessionManager - Propiedades incorrectas

**ERROR**: Se usa `UsuarioActual` pero la propiedad es `CurrentUser`.

**SOLUCIÓN**: Reemplazar en MainForm.cs:
```csharp
// INCORRECTO:
if (session.UsuarioActual != null)
{
    var userName = session.UsuarioActual.NombreCompleto;
    var roleName = session.UsuarioActual.RolNombre;
}

// CORRECTO:
if (session.CurrentUser != null)
{
    var userName = session.CurrentUser.NombreCompleto;
    var roleName = session.CurrentUser.RolNombre;
}
```

**ERROR**: Se usa `CerrarSesion()` pero el método es `Logout()`.

**SOLUCIÓN**: Reemplazar:
```csharp
// INCORRECTO:
SessionManager.Instance.CerrarSesion();

// CORRECTO:
SessionManager.Instance.Logout();
```

### 3. NuevaVentaForm - Constructor con 3 argumentos no existe

**ERROR**: Se llama `new NuevaVentaForm(_ventaService, _clienteService, _productoService)` pero el constructor puede tener diferentes parámetros.

**SOLUCIÓN TEMPORAL**: Usar el ServiceProvider:
```csharp
private void menuItemVentas_Click(object sender, EventArgs e)
{
    var form = Program.ServiceProvider.GetRequiredService<Forms.Ventas.NuevaVentaForm>();
    AbrirFormularioEnPanel(form);
}
```

---

## ?? ARCHIVO CORREGIDO COMPLETO: MainForm.cs

```csharp
using StockManager.BLL.Services;
using StockManager.BLL.Session;
using StockManager.DAL.UnitOfWork;
using StockManager.Services.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace StockManager.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ClienteService _clienteService;
        private readonly ProductoService _productoService;
        private readonly VentaService _ventaService;
        private readonly EmpleadoService _empleadoService;
        private readonly LocalizationService _localization;

        public MainForm(
            IUnitOfWork unitOfWork,
            ClienteService clienteService,
            ProductoService productoService,
            VentaService ventaService,
            EmpleadoService empleadoService)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _clienteService = clienteService;
            _productoService = productoService;
            _ventaService = ventaService;
            _empleadoService = empleadoService;
            _localization = LocalizationService.Instance;
            
            // Suscribirse al evento de cambio de idioma
            _localization.OnLanguageChanged += (s, lang) => AplicarTraducciones();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarInformacionUsuario();
            AplicarTraducciones();
            ConfigurarMenuIdioma();
        }

        private void ConfigurarMenuIdioma()
        {
            // Limpiar items existentes del menú idioma
            menuItemIdioma.DropDownItems.Clear();
            
            // Agregar idiomas disponibles
            var idiomas = _localization.GetAvailableLanguages();
            foreach (var idioma in idiomas)
            {
                var menuItem = new ToolStripMenuItem(idioma.Name);
                menuItem.Tag = idioma.Code;
                menuItem.Checked = (_localization.CurrentLanguage == idioma.Code);
                menuItem.Click += MenuItemIdioma_Click;
                menuItemIdioma.DropDownItems.Add(menuItem);
            }
        }

        private void MenuItemIdioma_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is string code)
            {
                _localization.SetLanguage(code);
                ConfigurarMenuIdioma(); // Actualizar checkmarks
            }
        }

        private void AplicarTraducciones()
        {
            // Actualizar menú principal
            menuItemVentas.Text = _localization.GetString("Menu_Sales");
            menuItemClientes.Text = _localization.GetString("Menu_Clients");
            menuItemProductos.Text = _localization.GetString("Menu_Products");
            menuItemStock.Text = _localization.GetString("Menu_Stock");
            menuItemReportes.Text = _localization.GetString("Menu_Reports");
            menuItemAdmin.Text = _localization.GetString("Menu_Admin");
            menuItemCerrarSesion.Text = _localization.GetString("Menu_Logout");
            menuItemIdioma.Text = _localization.GetString("Menu_Language");
        }

        private void CargarInformacionUsuario()
        {
            var session = SessionManager.Instance;
            if (session.CurrentUser != null)
            {
                var userName = session.CurrentUser.NombreCompleto;
                var roleName = session.CurrentUser.RolNombre;
                lblUsuarioInfo.Text = $"{userName} - {roleName}";
                
                // Configurar visibilidad de menús según rol
                ConfigurarMenusPorRol();
            }
        }

        private void ConfigurarMenusPorRol()
        {
            var session = SessionManager.Instance;
            if (session.CurrentUser == null) return;

            var rol = session.CurrentUser.RolNombre;

            // Admin: acceso total
            if (rol == "Administrador")
            {
                menuItemVentas.Visible = true;
                menuItemClientes.Visible = true;
                menuItemProductos.Visible = true;
                menuItemStock.Visible = true;
                menuItemReportes.Visible = true;
                menuItemAdmin.Visible = true;
            }
            // Administrador de Ventas
            else if (rol == "Administrador de Ventas")
            {
                menuItemVentas.Visible = true;
                menuItemClientes.Visible = true;
                menuItemProductos.Visible = false;
                menuItemStock.Visible = false;
                menuItemReportes.Visible = true;
                menuItemAdmin.Visible = false;
            }
            // Administrador de Depósito
            else if (rol == "Administrador de Depósito")
            {
                menuItemVentas.Visible = false;
                menuItemClientes.Visible = false;
                menuItemProductos.Visible = true;
                menuItemStock.Visible = true;
                menuItemReportes.Visible = true;
                menuItemAdmin.Visible = false;
            }
        }

        // Eventos de menú
        private void menuItemVentas_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Forms.Ventas.NuevaVentaForm>();
            AbrirFormularioEnPanel(form);
        }

        private void menuItemClientes_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Forms.Clientes.ClientesListForm>();
            AbrirFormularioEnPanel(form);
        }

        private void menuItemProductos_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Forms.Productos.ProductosListForm>();
            AbrirFormularioEnPanel(form);
        }

        private void menuItemStock_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Forms.Stock.StockForm>();
            AbrirFormularioEnPanel(form);
        }

        private void menuItemReportes_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Forms.Reportes.ReportesForm>();
            AbrirFormularioEnPanel(form);
        }

        private void menuItemAdmin_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Forms.Admin.AdminForm>();
            AbrirFormularioEnPanel(form);
        }

        private void menuItemCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                _localization.GetString("Msg_LogoutConfirm") ?? "¿Desea cerrar sesión?",
                _localization.GetString("Common_Confirmation"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Instance.Logout();
                this.Close();
            }
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            // Limpiar panel central
            panelCentral.Controls.Clear();

            // Configurar formulario
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Agregar al panel
            panelCentral.Controls.Add(formulario);
            formulario.Show();
        }
    }
}
```

---

## ? RESUMEN DE CAMBIOS NECESARIOS

1. **Eliminar** líneas 48-60 de MainForm.cs (ConfigurarEventosMenu y sus llamadas)
2. **Reemplazar** todas las ocurrencias de `UsuarioActual` ? `CurrentUser`
3. **Reemplazar** todas las ocurrencias de `CerrarSesion()` ? `Logout()`
4. **Actualizar** métodos de eventos de menú para que coincidan con el Designer
5. **Usar** `Program.ServiceProvider` para obtener formularios

---

## ?? INSTRUCCIONES MANUALES

Por favor, **copia el código MainForm.cs corregido** de arriba y reemplaza completamente el archivo actual.

Luego compila el proyecto:
```bash
dotnet build
```

---

**Nota**: Estos son los últimos ajustes necesarios para que el sistema de multi-idioma funcione completamente.
