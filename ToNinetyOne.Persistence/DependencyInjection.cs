using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToNinetyOneDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString"));
        });

        services.AddScoped<IToNinetyOneDbContext>(provider => provider.GetService<ToNinetyOneDbContext>());
        
        return services;
    }
}