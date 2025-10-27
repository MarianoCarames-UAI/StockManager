using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StockManager.Services.Configuration;

namespace StockManager.DAL.Context;

/// <summary>
/// Factory para crear el DbContext en tiempo de diseño (migraciones)
/// </summary>
public class StockManagerContextFactory : IDesignTimeDbContextFactory<StockManagerContext>
{
    public StockManagerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StockManagerContext>();
        
        // Obtener connection string de ApplicationSettings
        var connectionString = ApplicationSettings.Instance.ConnectionString;
        
        optionsBuilder.UseSqlServer(connectionString);

        return new StockManagerContext(optionsBuilder.Options);
    }
}
