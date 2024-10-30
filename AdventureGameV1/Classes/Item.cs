namespace AdventureGameV1.Classes
{
  public class Item {

    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description { get; set; } 
    public bool IsVisible { get; set; }

    public Item (int id, string name , string description, bool isVisible = true) {

      Id = id;
      Name = name;
      Description = description;
      IsVisible = isVisible;
    }

    public override string ToString()
    {
      return $"{Name} - {Description} - Visible: {IsVisible}";
    }
  }
}
