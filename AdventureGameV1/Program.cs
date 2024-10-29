using AdventureGameV1.Classes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace AdventureGameV1;

class Program
{

static void Main(string[] args)
  {

    // TODO: Cant get this to work. will set aside for now as it is driving me crazy
    // IConfigurationRoot config = new ConfigurationBuilder()
    //   .AddJsonFile("appsettings.json")
    //   .Build();
    //string dataPath = config.GetSection("dataPath").Value ?? string.Empty;

    string dataPath = "C:\\Users\\jimda\\dev\\c-sharp\\AdventureGameV1\\adventureGameV1\\data\\";
    if (!string.IsNullOrEmpty(dataPath))
    {
      Game game = new Game($"{dataPath}mapData.json", $"{dataPath}commandSetData.json");
      if (game.LoadState)
      {
        string command = "";
        Console.Clear();
        Console.WriteLine(game.player.CurrentLocation);

        do
        {
          Console.Write("> ");
          command = Console.ReadLine()!.ToLower();
          if (command.Length > 0)
          {
            game.ParseCommand(command, out string response);
            Console.WriteLine(response);
          }
        } while (command != "quit");
      } else {
        Console.WriteLine("Game failed to load");
      }
    } else {
      Console.WriteLine("Path to data not found in app.config");
    }
  }
}
