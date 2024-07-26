using ConsoleAPI.API.Menu;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAPI.API;

class Program
{
    private static readonly IServiceProvider ServiceProvider = 
        Startup.ConfigureServices().BuildServiceProvider();
    
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Введите комманду!");
            var command = Console.ReadLine().Split();
            
            var commandFactory = new CommandFactory(ServiceProvider);

            try
            {
                var commandHandler = commandFactory.CreateOperation(command);
                await commandHandler.Handle(command);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}