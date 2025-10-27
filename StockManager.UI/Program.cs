using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockManager.BLL.Services;
using StockManager.DAL.Context;
using StockManager.DAL.UnitOfWork;
using StockManager.Services.Configuration;
using StockManager.UI.Forms;

namespace StockManager.UI;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Configurar servicios con Dependency Injection
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        // Mostrar formulario de login
        var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
        var loginResult = loginForm.ShowDialog();

        if (loginResult == DialogResult.OK)
        {
            // Si el login fue exitoso, mostrar formulario principal
            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
        else
        {
            // Si se canceló el login, cerrar aplicación
            Application.Exit();
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Configuración
        var settings = ApplicationSettings.Instance;

        // DbContext con SQL Server
        services.AddDbContext<StockManagerContext>(options =>
            options.UseSqlServer(settings.ConnectionString));

        // Unit of Work y Repositorios
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Servicios de Negocio (BLL)
        services.AddScoped<AuthService>();
        services.AddScoped<ClienteService>();
        services.AddScoped<ProductoService>();
        services.AddScoped<VentaService>();
        services.AddScoped<EmpleadoService>();

        // Formularios
        services.AddTransient<LoginForm>();
        services.AddTransient<MainForm>();
        
        // Clientes
        services.AddTransient<Forms.Clientes.ClientesListForm>();
        services.AddTransient<Forms.Clientes.ClienteEditForm>();
        
        // Productos
        services.AddTransient<Forms.Productos.ProductosListForm>();
        services.AddTransient<Forms.Productos.ProductoEditForm>();
        
        // Ventas
        services.AddTransient<Forms.Ventas.VentasListForm>();
        services.AddTransient<Forms.Ventas.NuevaVentaForm>();
        
        // Stock
        services.AddTransient<Forms.Stock.StockForm>();
        services.AddTransient<Forms.Stock.EditarStockForm>();
        
        // Reportes
        services.AddTransient<Forms.Reportes.ReportesForm>();
        
        // Admin
        services.AddTransient<Forms.Admin.AdminForm>();
        services.AddTransient<Forms.Admin.EmpleadoEditForm>();
        services.AddTransient<Forms.Admin.CambiarPasswordForm>();
    }
}