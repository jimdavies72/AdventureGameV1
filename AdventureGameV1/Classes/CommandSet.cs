
namespace AdventureGameV1.Classes
{
  public class CommandSet
  {
    public List<Command> Commands { get; set; }

    public CommandSet()
    {
      Commands = new List<Command>();
    }

    public bool ParseCommand(string commandText)
    {
      for (int i = 0; i < Commands.Count; i++){
        if (Commands[i].CommandText.Equals(commandText.ToLower()))
        {
          return true;
        }
      }

      return false;
    }

    public override string ToString()
    { 
      if (Commands.Count == 0)
      {
        return "\nNo Commands Availalble\n";
      }

      string text = "\nAvailable Commands:\n\n";
      for (int i = 0; i < Commands.Count; i++)
      {
        text += $"{Commands[i].CommandText} ({Commands[i].ShortCommandText})\n";
      }

      return text;
    }

  }
}