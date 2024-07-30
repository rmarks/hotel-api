namespace Hotel.Domain.Model;

public class Room
{
    public int Id { get; set; }
    public string RoomNo { get; set; } = string.Empty;
    public int NumOfBeds { get; set; }
}
