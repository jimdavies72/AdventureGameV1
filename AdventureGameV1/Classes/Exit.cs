namespace AdventureGameV1.Classes
{
  public class Exit
  {
    public string Direction { get; init; }
    public int ToRoomId { get; init; }

    public Exit(string direction, int toRoomId)
    {
      Direction = direction;
      ToRoomId = toRoomId;
    }

    public override string ToString()
    {
        return $"{Direction}, To Room: {ToRoomId}";
    }
  }
}