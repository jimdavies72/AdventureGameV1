namespace AdventureGameV1.Classes
{
  public class Map
  {
    public List<Room> Rooms { get; set; }

    public Map()
    {
      Rooms = new List<Room>();
    }

    public bool FindRoomInList(int roomId, List<Room> rooms, out Room room)
    {
      room = new Room(default, string.Empty, string.Empty);

      if (rooms.Count > 0)
      {
        for (int i = 0; i < rooms.Count; i++)
        {
          if (rooms[i].Id == roomId)
          {
            room = rooms[i];
            return true;
          }
        }
      }

      return false;
    }

    public override string ToString()
    {
      return $"Map:\n{string.Join(",\n", Rooms)}";
    }
  }
}