
using System.Text.Json;

namespace AdventureGameV1.Classes
{
  public class Game 
  {
    public bool LoadState {get; set;}
    public Map GameMap {get; set;}
    public Room CurrentLocation {get; set;}
    public CommandSet GameCommands {get; set;}

    public Game(string mapDataFilename, string commandSetFilename)
    // construct the game environment
    {
      CurrentLocation = new Room(-1, "The Void", "There is nothing here.");
      GameMap = new Map();
      LoadState = LoadMap(mapDataFilename);

      GameCommands = new CommandSet();
      LoadState = LoadCommands(commandSetFilename);
    }

    private bool LoadMap(string filename)
    {
      try
      {
        if (GetData(filename, out string jsonString))
        {
          GameMap = JsonSerializer.Deserialize<Map>(jsonString)!;
          if (GameMap.Rooms.Count > 0)
          {
            //set starting position
            if (GameMap.FindRoomInList(0, GameMap.Rooms, out Room room))
            {
              CurrentLocation = room;
            }
          }
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
