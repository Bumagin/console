using ConsoleAPI.Application.Users.Dto;
using FluentValidation;

namespace ConsoleAPI.Application.Users.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Поле FirstName обязательно!");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Поле LastName обязательно!");
        RuleFor(x => x.SalaryPerHour).GreaterThan(0).WithMessage("SalaryPerHour должна быть больше 0!");
    }
}