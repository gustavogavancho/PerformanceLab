using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerformanceLab.Application.Abstractions.Persistence;
using PerformanceLab.Persistence.SqlServer.Context;
using PerformanceLab.Persistence.SqlServer.Repositories;

namespace PerformanceLab.Persistence.SqlServer;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServerPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}