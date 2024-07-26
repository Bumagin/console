using ConsoleAPI.Application.Users;
using ConsoleAPI.Application.Users.Dto;
using FluentValidation;
using FluentValidation.Results;

namespace ConsoleAPI.API.Menu.Commands;

public class AddCommandHandler : ICommandHandler
{
    private readonly IUserAppService _userAppService;
    private readonly IValidator<UserDto> _validator;

    public AddCommandHandler(
        IUserAppService userAppService, 
        IValidator<UserDto> validator)
    {
        _userAppService = userAppService;
        _validator = validator;
    }

    public async Task Handle(string[] args)
    {
        var user = new UserDto
        {
            FirstName = args[1].Split(':')[1],
            LastName = args[2].Split(':')[1],
            SalaryPerHour = decimal.Parse(args[3].Split(':')[1])
        };

        await _validator.ValidateAndThrowAsync(user);
        
        await _userAppService.CreateOrUpdate(user);
        Console.WriteLine("User успешно создан!");
    }
}