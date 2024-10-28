using AdventureGameV1.Classes;
using System.Configuration;

namespace AdventureGameV1;

class Program
{
  static void Main(string[] args)
  {
    string dataPath = ConfigurationManager.AppSettings.Get("dataPath") ?? "";
    if (!string.IsNullOrEmpty(dataPath))
    {
      Game game = new Game($"{dataPath}data/mapData.json", $"{dataPath}data/commandSetData.json");
      if (game.LoadState)
      {
        string command = "";
        Console.Clear();
        Console.WriteLine(game.CurrentLocation);

        do
        {
          Console.Write("> ");
          command = Console.ReadLine()!.ToLower();
          Console.WriteLine("you entered: " + command);
        } while (command != "quit");
      } else {
        Console.WriteLine("Game failed to load");
      }
    } else {
      Console.WriteLine("Path to data not found in app.config");
    }
  }
}
