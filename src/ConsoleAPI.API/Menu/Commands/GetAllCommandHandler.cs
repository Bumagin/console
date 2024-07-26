using ConsoleAPI.Application.Users;

namespace ConsoleAPI.API.Menu.Commands;

public class GetAllCommandHandler : ICommandHandler
{
    private readonly IUserAppService _userAppService;

    public GetAllCommandHandler(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task Handle(string[] args)
    {
        var users = _userAppService.GetAll();
        foreach (var user in users.Items)
        {
            Console.WriteLine($"Id = {user.Id}, FirstName = {user.FirstName}, LastName = {user.LastName}, SalaryPerHour = {user.SalaryPerHour}");
        }
    }
}