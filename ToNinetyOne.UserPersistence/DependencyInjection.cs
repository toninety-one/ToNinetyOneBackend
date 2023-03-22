using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Persistence;

namespace ToNinetyOne.UserPersistence;

public static class DependencyInjection
{
    public static IServiceCollection AddUserPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<ToNinetyOneUserDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("SqliteUserConnectionString"));
        });
        
        services.AddScoped<IToNinetyOneUserDbContext>(provider => provider.GetService<IToNinetyOneUserDbContext>());

        return services;
    }
}