using ConsoleAPI.Application.Users.Dto;
using ConsoleAPI.Common.Dto;

namespace ConsoleAPI.Application.Users;

public interface IUserAppService
{
    Task CreateOrUpdate(UserDto input);
    UserDto GetById(int userId);
    Task Delete(int userId);
    ListResultDto<UserDto> GetAll();
}