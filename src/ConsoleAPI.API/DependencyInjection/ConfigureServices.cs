using ConsoleAPI.API.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAPI.API.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddScoped<GetAllCommandHandler>();
        services.AddScoped<GetCommandHandler>();
        services.AddScoped<AddCommandHandler>();
        services.AddScoped<DeleteCommandHandler>();
        services.AddScoped<UpdateCommandHandler>();
    }
}