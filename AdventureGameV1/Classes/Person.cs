namespace AdventureGameV1.Classes
{
  public class Person
  {
    public string Name { get; set; }
    public Room CurrentLocation { get; set; }
    public ItemList Inventory { get; set; }

    public Person(string name, Room startingLocation)
    {
      Name = name;
      CurrentLocation = startingLocation;
      Inventory = new ItemList(2);
    }

    public bool PickUpItem(Item item)
    {
      if (Inventory.AddItem(item))
      {
        CurrentLocation.Items.Remove(item);
        return true;
      }
      return false;
    }

    public bool DropItem(Item item)
    {
      if (Inventory.Items.Contains(item))
      {
        CurrentLocation.Items.Add(item);
        return Inventory.Remove(item);
      }
      return false;
    }

    public void ListInventory(){

      if (Inventory.Items.Count.Equals(0))
      {
        Console.WriteLine("Your inventory is empty.");
      } else {
        Console.WriteLine("Your inventory contains: ");
        foreach (var item in Inventory.Items)
        {
          Console.WriteLine(item);
        }
      }
    }
  }
}