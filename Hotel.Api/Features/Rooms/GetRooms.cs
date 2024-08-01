using Hotel.Api.Utils;
using Mapster;

namespace Hotel.Api.Features.Rooms;

public record RoomListModel(int Id, string RoomNo, int NumOfBeds);

public static class GetRooms
{
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/rooms", Handler)
                .WithTags("Rooms");
        }
    }

    public static async Task<IEnumerable<RoomListModel>> Handler(HotelContext db)
    {
        return await db.Rooms
            .AsNoTracking()
            .OrderBy(r => r.RoomNo)
            .ProjectToType<RoomListModel>()
            .ToListAsync();
    }
}
