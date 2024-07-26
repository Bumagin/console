using ConsoleAPI.Application.Users.Dto;
using ConsoleAPI.Common.Dto;
using ConsoleAPI.Domain.Users;

namespace ConsoleAPI.Application.Users;

public class UserAppService : IUserAppService
{
    private readonly IUserRepository _userRepository;

    public UserAppService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateOrUpdate(UserDto input)
    {
        if (input.Id.HasValue)
            await Update(input);
        else
            await Create(input);
    }

    public UserDto GetById(int userId)
    {
        var user = _userRepository.GetById(userId);

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            SalaryPerHour = user.SalaryPerHour
        };
    }

    public async Task Delete(int userId)
    {
        await _userRepository.Delete(userId);
    }

    public ListResultDto<UserDto> GetAll()
    {
        var users = _userRepository.GetAll()
            .Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SalaryPerHour = user.SalaryPerHour
            }).ToList();

        return new ListResultDto<UserDto>
        {
            Items = users
        };
    }

    // SUPPORT

    private async Task Create(UserDto input)
    {
        var user = new User
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            SalaryPerHour = input.SalaryPerHour
        };

        await _userRepository.Create(user);
    }

    private async Task Update(UserDto input)
    {
        var user = new User
        {
            Id = input.Id.Value,
            FirstName = input.FirstName,
            LastName = input.LastName,
            SalaryPerHour = input.SalaryPerHour
        };

        await _userRepository.Update(user);
    }
}