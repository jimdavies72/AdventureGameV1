namespace AdventureGameV1.Classes
{
  public class Person
  {
    public string Name { get; set; }
    public Room CurrentLocation { get; set; }

    public Person(string name, Room startingLocation)
    {
      Name = name;
      CurrentLocation = startingLocation;
      
    }
  }
}