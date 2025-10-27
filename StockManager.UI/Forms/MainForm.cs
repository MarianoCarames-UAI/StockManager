using StockManager.BLL.Services;
using StockManager.BLL.Session;
using StockManager.DAL.UnitOfWork;
using StockManager.Services.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace StockManager.UI.Forms
{
    /// <summary>
    /// Formulario principal de la aplicación
    /// </summary>
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
            menuItemSalir.Text = _localization.GetString("Menu_Exit");
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
                // Cerrar sesión y volver al login
                SessionManager.Instance.Logout();
                this.Hide();
                
                // Mostrar el formulario de login nuevamente
                var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                var loginResult = loginForm.ShowDialog();
                
                if (loginResult == DialogResult.OK)
                {
                    // Si login exitoso, recargar el MainForm con el nuevo usuario
                    CargarInformacionUsuario();
                    this.Show();
                }
                else
                {
                    // Si canceló el login, cerrar la aplicación
                    Application.Exit();
                }
            }
        }

        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                _localization.GetString("Msg_ExitConfirm") ?? "¿Está seguro que desea salir de la aplicación?",
                _localization.GetString("Common_Confirmation"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Instance.Logout();
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Solo confirmar si el usuario cierra con la X
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    _localization.GetString("Msg_ExitConfirm") ?? "¿Está seguro que desea salir de la aplicación?",
                    _localization.GetString("Common_Confirmation"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    SessionManager.Instance.Logout();
                }
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
