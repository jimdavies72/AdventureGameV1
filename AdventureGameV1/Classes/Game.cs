

using System.Text.Json;

namespace AdventureGameV1.Classes
{
  public class Game 
  {
    public bool LoadState {get; set;}
    public Map GameMap {get; set;}
    public CommandSet GameCommands {get; set;}
    public Person Player {get; set;}

    public Game(string mapDataFilename, string commandSetFilename)
    // construct the game environment
    {
      GameMap = new Map();
      LoadState = LoadMap(mapDataFilename);

      GameCommands = new CommandSet();
      LoadState = LoadCommands(commandSetFilename);

      // create person with name and starting location
      if (GameMap.FindRoomInList(0, GameMap.Rooms, out Room room))
      {
        Player = new Person("Player", room);
      } else
      {
        Player = null!;
        LoadState = false;
      }
    }

    private bool LoadMap(string filename)
    {
      try
      {
        if (Data.GetData(filename, out string jsonString))
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
        if (Data.GetData(filename, out string jsonString))
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
      Console.WriteLine();
      response = string.Empty;
      if (commandText.Length.Equals(0))
      {
        Console.WriteLine("... nothing happens ...\n");
        return false;
      }

      var commandList = commandText.ToLower().Trim().Split(" ").ToList(); 
      var success = true;

      if (GameCommands.ConfirmCommand(commandList[0], out string commandType))
      {
        switch (commandType)
        {
          case "move":
            MoveCommand(commandList[0]);
            break;
          case "game":
            GameCommand(commandList[0]);
            break;
          case "action":
            ActionCommand(commandList[0], commandList[1]);
            break;
          default: 
            Console.WriteLine($"Some other command type: {commandType}");
            break;
        }
      } else
      {
        // no matching command found
        response = "I don't understand that command. Please try again.\n";
        success = false;
      }
      return success;
    }

    private bool Move(int roomId)
    {
      if (GameMap.FindRoomInList(roomId, GameMap.Rooms, out Room room))
      {
        Player.CurrentLocation = room;
        Console.WriteLine(Player.CurrentLocation);
        return true;
      }

      return false;
    }

    private void MoveCommand(string commandText)
    {
      foreach (var exit in Player.CurrentLocation.Exits)
      {
        if (exit.Direction.ToLower().Equals(commandText))
        {
          Move(exit.ToRoomId);
        }
      }
    }

    private void GameCommand(string commandText)
    {
      if (commandText.ToLower().Equals("inventory") || commandText.ToLower().Equals("inv"))
      {
        Player.ListInventory();
      } else if (commandText.ToLower().Equals("look"))
      {
        try
        {
          Console.Clear();
        } catch (IOException)
        {
        }

        Console.WriteLine(Player.CurrentLocation);
      } else if (commandText.ToLower().Equals("help") || commandText.ToLower().Equals("?"))
      {
        Console.WriteLine(GameCommands);
      }
    }

    private void ActionCommand(string commandText, string itemText = "")
    {
      if (commandText.ToLower().Equals("get"))
      {
        var itemToPickUp = Player.CurrentLocation.Items.FirstOrDefault(i => i.Name.ToLower().Equals(itemText));
        if (itemToPickUp != null)
        {
          if (Player.PickUpItem(itemToPickUp)){
            Console.WriteLine($"You picked up the {itemToPickUp.Name}");
          } else
          {
            Console.WriteLine($"I cannot pick up the item {itemText} as you are carrying the maximum number of items in your inventory already");
          }
        }
        else
        {
          Console.WriteLine($"I cannot see the item {itemText}");
        }
      }
      else if (commandText.ToLower().Equals("drop"))
      {
        var itemToDrop = Player.Inventory.Items.FirstOrDefault(i => i.Name.ToLower().Equals(itemText));
        if (itemToDrop != null)
        {
          Player.DropItem(itemToDrop);
          Console.WriteLine($"You dropped the {itemToDrop.Name}");
        }
        else
        {
          Console.WriteLine($"I do not have the item {itemText}");
        }
      }
    }
  }
}
