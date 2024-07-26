using ConsoleAPI.Application.Users;

namespace ConsoleAPI.API.Menu.Commands;

public class GetCommandHandler : ICommandHandler
{
    private readonly IUserAppService _userAppService;

    public GetCommandHandler(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task Handle(string[] args)
    {
        var userId = int.Parse(args[1].Split(':')[1]);
        var user = _userAppService.GetById(userId);
        
        Console.WriteLine($"Id = {user.Id}, FirstName = {user.FirstName}, LastName = {user.LastName}, SalaryPerHour = {user.SalaryPerHour}");
    }
}