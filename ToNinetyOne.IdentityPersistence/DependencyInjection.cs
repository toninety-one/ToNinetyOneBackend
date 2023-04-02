using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToNinetyOne.Identity.Interfaces;

namespace ToNinetyOne.IdentityPersistence;

public static class DependencyInjection
{
    public static IServiceCollection AddUserPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToNinetyOneUserDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("SqliteUserConnectionString"));
        });

        services.AddScoped<IToNinetyOneUserDbContext>(provider => provider.GetService<ToNinetyOneUserDbContext>());
        
        return services;
    }
}