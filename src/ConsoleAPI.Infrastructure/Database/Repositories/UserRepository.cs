using ConsoleAPI.Domain.Users;

namespace ConsoleAPI.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContext _context = new();

    public async Task Create(User user)
    {
        var users = _context.Users;
        
        user.Id = users.Any()
            ? users.Max(u => u.Id) + 1
            : 1;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        var currentUser = GetById(user.Id);

        currentUser.FirstName = user.FirstName;
        currentUser.LastName = user.LastName;
        currentUser.SalaryPerHour = user.SalaryPerHour;

        _context.Users.Remove(user);
        _context.Users.Add(currentUser);
        
        await _context.SaveChangesAsync();
    }

    public User GetById(int userId)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Id.Equals(userId));

        if (user is null)
            throw new KeyNotFoundException($"User с Id {userId} не найден!");

        return user;
    }

    public async Task Delete(int userId)
    {
        var user = GetById(userId);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public List<User> GetAll()
    {
        return _context.Users;
    }
}