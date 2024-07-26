using ConsoleAPI.Domain.Users;
using Newtonsoft.Json;

namespace ConsoleAPI.Infrastructure.Database;

public class DbContext
{
    public DbContext()
    {
        Users = LoadUsers();
    }

    public List<User> Users { get; set; }
    
    private List<User> LoadUsers()
    {
        var json = File.ReadAllText(AppConst.DbFileName);
        return JsonConvert.DeserializeObject<List<User>>(json) ?? [];
    }
    
    public async Task SaveChangesAsync()
    {
        var json = JsonConvert.SerializeObject(Users, Formatting.Indented);
        await File.WriteAllTextAsync(AppConst.DbFileName, json);
    }
}