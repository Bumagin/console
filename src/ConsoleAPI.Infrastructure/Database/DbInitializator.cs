using ConsoleAPI.Domain.Users;
using Newtonsoft.Json;

namespace ConsoleAPI.Infrastructure.Database;

public class DbInitializator
{
    public void Initialize()
    {
        if (!File.Exists(AppConst.DbFileName))
        {
            string json = JsonConvert.SerializeObject(new List<User>(), Formatting.Indented);

            File.WriteAllTextAsync(AppConst.DbFileName, json);
            Console.WriteLine("База данных успешно создана!");
        }
    }
}