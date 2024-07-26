using ConsoleAPI.Application.Users;
using ConsoleAPI.Application.Users.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAPI.Application.DependencyInjection;

public static class ConfigureServices
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
    }
}