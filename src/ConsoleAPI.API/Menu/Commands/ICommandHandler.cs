namespace ConsoleAPI.API.Menu.Commands;

public interface ICommandHandler
{
    Task Handle(string[] args);
}