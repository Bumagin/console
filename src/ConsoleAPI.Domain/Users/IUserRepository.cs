namespace ConsoleAPI.Domain.Users;

public interface IUserRepository
{
    Task Create(User user);
    Task Update(User user);
    User GetById(int userId);
    Task Delete(int userId);
    List<User> GetAll();
}