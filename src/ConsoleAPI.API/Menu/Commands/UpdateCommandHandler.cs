using ConsoleAPI.Application.Users;

namespace ConsoleAPI.API.Menu.Commands;

public class UpdateCommandHandler : ICommandHandler
{
    private readonly IUserAppService _userAppService;

    public UpdateCommandHandler(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task Handle(string[] args)
    {
        var userId = int.Parse(args[1].Split(':')[1]);
        var updates = new Dictionary<string, string>();

        for (int i = 2; i < args.Length; i++)
        {
            var keyValue = args[i].Split(':');
            updates[keyValue[0]] = keyValue[1];
        }

        var user = _userAppService.GetById(userId);

        if (updates.ContainsKey("FirstName")) user.FirstName = updates["FirstName"];
        if (updates.ContainsKey("LastName")) user.LastName = updates["LastName"];
        if (updates.ContainsKey("SalaryPerHour")) user.SalaryPerHour = decimal.Parse(updates["SalaryPerHour"]);

        await _userAppService.CreateOrUpdate(user);
        Console.WriteLine("User успешно обновлен!");
    }
}