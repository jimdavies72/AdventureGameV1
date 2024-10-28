namespace AdventureGameV1.Classes
{
  public class Item {

    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description { get; set; } 

    public Item (int id, string name , string description) {

      Id = id;
      Name = name;
      Description = description;
    }
  }
}
