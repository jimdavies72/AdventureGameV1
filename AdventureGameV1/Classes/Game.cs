
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AdventureGameV1.Classes
{
  public class Game 
  {
    public bool LoadState {get; set;}
    public Map GameMap {get; set;}
    //public Room CurrentLocation {get; set;}
    public CommandSet GameCommands {get; set;}
    public Person player {get; set;}

    public Game(string mapDataFilename, string commandSetFilename)
    // construct the game environment
    {
      GameMap = new Map();
      LoadState = LoadMap(mapDataFilename);

      GameCommands = new CommandSet();
      LoadState = LoadCommands(commandSetFilename);

      // create person with  name and starting location
      if (GameMap.FindRoomInList(0, GameMap.Rooms, out Room room))
      {
        player = new Person("Player", room);
      } else
      {
        player = null!;
        LoadState = false;
      }

    }

    private bool LoadMap(string filename)
    {
      try
      {
        if (GetData(filename, out string jsonString))
        {
          GameMap = JsonSerializer.Deserialize<Map>(jsonString)!;
          return true;
        }
        return false;
      }
      catch
      {
        return false;
      }
    }

    private bool LoadCommands(string filename)
    {
      try
      {
        if (GetData(filename, out string jsonString))
        {
          GameCommands = JsonSerializer.Deserialize<CommandSet>(jsonString)!;
          if (GameCommands.Commands.Count > 0)
          {
            return true;
          }
        }
        return false;
      } catch
      {
        return false;
      }
    }

    public bool ParseCommand(string commandText, out string response)
    {
      response = string.Empty;
      if (commandText.Length == 0)
      {
        return false;
      }

      commandText = Regex.Replace(commandText.ToLower(), @"\s+", string.Empty);
      var commandList = commandText.Split(" ").ToList();
      
      if (GameCommands.ConfirmCommand(commandList[0], out string commandType))
      {
        // command found
        if (commandType == "move")
        {
          foreach (var exit in player.CurrentLocation.Exits)
          {
            if (exit.Direction.ToLower().Equals(commandList[0]))
            {
              Move(exit.ToRoomId);
            }
          }  
        } else
        {
          Console.WriteLine($"Some other command type: {commandType}");
        }
        return true;
      } else
      {
        // no matching command found
        response = "I don't understand that command. Please try again.\n";
        return false;
      }
    }

    private bool Move(int roomId)
    {
      if (GameMap.FindRoomInList(roomId, GameMap.Rooms, out Room room))
      {
        player.CurrentLocation = room;
        Console.WriteLine(player.CurrentLocation);
        return true;
      }

      return false;
    }

    static bool GetData(string fileName,out string jsonString)
    {
      try
      {
        jsonString = File.ReadAllText(fileName);
        return true;

      } catch (Exception e)  {
        Console.WriteLine("Exception: " + e.Message);
        jsonString = string.Empty;
        return false;
      }
    }
  }
}
