using ConsoleAPI.API.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAPI.API.Menu;

public class CommandFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    public CommandFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommandHandler CreateOperation(string[] args)
    {
        return args[0] switch
        {
            "-add" => _serviceProvider.GetRequiredService<AddCommandHandler>(),
            "-update" => _serviceProvider.GetRequiredService<UpdateCommandHandler>(),
            "-get" => _serviceProvider.GetRequiredService<GetCommandHandler>(),
            "-delete" => _serviceProvider.GetRequiredService<DeleteCommandHandler>(),
            "-getall" => _serviceProvider.GetRequiredService<GetAllCommandHandler>(),
            _ => throw new KeyNotFoundException("Команда не распознана!")
        };
    }
}