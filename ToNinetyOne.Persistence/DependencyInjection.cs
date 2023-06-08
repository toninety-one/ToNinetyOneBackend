using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddDbContext<ToNinetyOneDbContext>(options =>
        {
            if (isDevelopment)
                options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString"));
            else
                options.UseNpgsql(configuration.GetConnectionString("PostgresqlConnectionString"));
        });

        services.AddScoped<IToNinetyOneDbContext>(provider => provider.GetService<ToNinetyOneDbContext>() ?? throw new
            InvalidOperationException());

        return services;
    }
}