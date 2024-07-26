using ConsoleAPI.Domain.Users;
using ConsoleAPI.Infrastructure.Database;
using ConsoleAPI.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAPI.Infrastructure.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddScoped<DbContext>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}