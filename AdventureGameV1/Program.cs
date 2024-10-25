using System.Data;
using AdventureGameV1.Classes;

namespace AdventureGameV1;

class Program
{
  static void Main(string[] args)
  {
    Game game = new Game("data/mapData.json"); //bin/data/mapData.json
    
    if (game.LoadState)
    {
      string command = "";
      
      Console.Clear();
      Console.WriteLine(game.CurrentLocation);

      do
      {
        Console.Write("> ");
        command = Console.ReadLine()!;
        Console.WriteLine("you entered: " + command);
      } while (command != "quit");
    } else {
      Console.WriteLine("Game failed to load");
    }
  }
}
