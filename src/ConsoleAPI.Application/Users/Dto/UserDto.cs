using ConsoleAPI.Common.Abstractions;

namespace ConsoleAPI.Application.Users.Dto;

public class UserDto : EntityDto<int?>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal SalaryPerHour { get; set; }

    public override string ToString()
    {
        return $"Приeвет, меня зовут {FirstName}";
    }
}