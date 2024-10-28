
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace AdventureGameV1.Classes
{
  public class Room
  {
    private int id;
    private string name = "";
    private string description = "";
    public List<Item> Items { get; set; }

    public int Id
    {
      get => id;
      set => id = value >= 0 ? value : -1;
    }

    public string Name
    {
      get => name;
      set => name = !string.IsNullOrEmpty(value) ? value : "Invalid Name";
    }

    public string Description
    {
      get => description;
      set => description = !string.IsNullOrEmpty(value) ? value : "Invalid Description";
    }

    public List<Exit> Exits { get; set; } 

    public Room(int id, string name, string description)
    {
      Id = id;
      Name = name;
      Description = description;
      Exits = new List<Exit>();
      Items = new List<Item>(); 
    }

    public override string ToString()
    {
      string description = $"Id: {Id} - Name: {Name}\nDescription: {Description}\nExits are: {string.Join(", ", Exits)}";
      
      return description;
    }
  }
}