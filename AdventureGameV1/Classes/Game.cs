
using System.Text.Json;

namespace AdventureGameV1.Classes
{
  public class Game 
  {
    public string Filename {get; set;}
    public bool LoadState {get; set;}
    public Map Map {get; init;}
    private Room currentLocation = new Room(-1, "The Void", "There is nothing here.");

    public Game(string fileName)
    // construct the game environment
    {
      LoadState = false;
      Filename = fileName;
      Map = new Map();

      try 
      {
        if (GetMapData(Filename, out string jsonString))
        {
          Map = JsonSerializer.Deserialize<Map>(jsonString)!;
          if (Map.Rooms.Count > 0)
          {
            LoadState = true;
            //set starting position
            if (Map.FindRoomInList(0, Map.Rooms, out Room room))
            {
              CurrentLocation = room;
            }
          }
        }
      } catch {
        LoadState = false;
      }
      
    }

    public Room CurrentLocation
    {
      get
      {
        return currentLocation;
      }

      set
      {
        currentLocation = value;
      }
    }

    static bool GetMapData(string fileName,out string jsonString)
    {
      try
      {
        jsonString = File.ReadAllText(fileName);
        return true;

      } catch  {
        jsonString = string.Empty;
        return false;
      }
    }
  }
}
