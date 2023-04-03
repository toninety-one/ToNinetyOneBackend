using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToNinetyOne.Identity.Interfaces;

namespace ToNinetyOne.IdentityPersistence;

public static class DependencyInjection
{
    public static IServiceCollection AddUserPersistence(this IServiceCollection services, IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddDbContext<ToNinetyOneUserDbContext>(options =>
        {
            if (isDevelopment)
            {
                options.UseSqlite(configuration.GetConnectionString("SqliteUserConnectionString"));
            }
            else
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgresqlUserConnectionString"));
            }
        });

        services.AddScoped<IToNinetyOneUserDbContext>(provider => provider.GetService<ToNinetyOneUserDbContext>());

        return services;
    }
}