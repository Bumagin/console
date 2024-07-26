using ConsoleAPI.API.DependencyInjection;
using ConsoleAPI.Application.DependencyInjection;
using ConsoleAPI.Infrastructure.Database;
using ConsoleAPI.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAPI.API;

public static class Startup
{
    public static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddApplicationLayer();
        services.AddInfrastructureLayer();
        services.AddCommands();

        new DbInitializator().Initialize();
        
        return services;
    }
}