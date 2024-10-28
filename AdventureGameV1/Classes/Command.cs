namespace AdventureGameV1.Classes
{
  public class Command
  {
    public string CommandText { get; init; }
    public string ShortCommandText { get; init; }

    public Command(string commandText, string shortCommandText)
    {
      CommandText = commandText;
      ShortCommandText = shortCommandText;
    }
  }
}