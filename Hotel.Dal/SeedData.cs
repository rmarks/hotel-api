using Hotel.Domain.Model;

namespace Hotel.Dal;

public class SeedData
{
    public static void Seed(HotelContext db)
    {
        db.Database.EnsureCreated();

        db.Rooms.AddRange(
            new Room { RoomNo = "101", NumOfBeds = 2 },
            new Room { RoomNo = "102", NumOfBeds = 2 },
            new Room { RoomNo = "201", NumOfBeds = 3 },
            new Room { RoomNo = "202", NumOfBeds = 3 });

        db.SaveChanges();
    }
}
