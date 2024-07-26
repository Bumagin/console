using ConsoleAPI.Common.Abstractions;

namespace ConsoleAPI.Domain.Users;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal SalaryPerHour { get; set; }
}