namespace AdventureGameV1.Classes
{
  public class ItemList
  {
    public List<Item> Items { get; set; }
    public int MaxItems { get; set; }
    public int CurrentItems => Items.Count;

    public ItemList(int maxItems)
    {
      Items = new List<Item>();

      if (maxItems < 0)
      {
        throw new Exception("maxItems must be greater than 0");
      }
      
      if (maxItems == default) // pseudo infinite items
      {
        MaxItems = 999;
      } else {
        MaxItems = maxItems;
      }
    }

    public bool AddItem(Item item)
    {
      if (CurrentItems < MaxItems)
      {
        Items.Add(item);
        return true;
      }
      return false;
    }

    public bool Remove(Item item)
    {
      if (Items.Remove(item))
      {
        return true;
      }
      return false;
    }
  }
}