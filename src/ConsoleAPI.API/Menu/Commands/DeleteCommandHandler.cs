using ConsoleAPI.Application.Users;

namespace ConsoleAPI.API.Menu.Commands;

public class DeleteCommandHandler : ICommandHandler
{
    private readonly IUserAppService _userAppService;

    public DeleteCommandHandler(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task Handle(string[] args)
    {
        var userId = int.Parse(args[1].Split(':')[1]);
        
        await _userAppService.Delete(userId);
        Console.WriteLine("User успешно удален!");
    }
}