using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Infrastructure.Contexts;

namespace TaxCalculator.Infrastructure;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContextFactory<AppDbContext>(options =>
        {
            var connection = new SqliteConnection("DataSource=TaxCalculatordDb;mode=memory;cache=shared");
            connection.Open();

            options.UseSqlite(connection);
        });

        services.AddTransient<IPersistence>(provider =>
        {
            var factory = provider.GetRequiredService<IDbContextFactory<AppDbContext>>();
            var context = factory.CreateDbContext();
            return context;
        });

        return services;
    }
}
