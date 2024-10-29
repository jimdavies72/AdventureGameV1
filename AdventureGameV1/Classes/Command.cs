namespace AdventureGameV1.Classes
{
  public class Command
  {
    public string CommandText { get; init; }
    public string ShortCommandText { get; init; }
    public string CommandType { get; init; }

    public Command(string commandText, string shortCommandText, string commandType)
    {
      CommandText = commandText;
      ShortCommandText = shortCommandText;
      CommandType = commandType;
    }
  }
}