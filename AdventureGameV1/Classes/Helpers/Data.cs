namespace AdventureGameV1.Classes
{
  public class Data
  {
    public static bool GetData(string fileName, out string jsonString)
    {
      try
      {
        jsonString = File.ReadAllText(fileName);
        return true;

      }
      catch (Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
        jsonString = string.Empty;
        return false;
      }
    }
  }
}