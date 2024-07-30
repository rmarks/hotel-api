using Hotel.Api.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Api.Features.Rooms;

public record RoomListDto(int Id, string RoomNo, int NumOfBeds);

public static class GetRooms
{
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/rooms", Handler);
        }
    }

    public static async Task<IEnumerable<RoomListDto>> Handler(HotelContext db)
    {
        return await db.Rooms
            .AsNoTracking()
            .OrderBy(r => r.RoomNo)
            .Select(r => new RoomListDto(r.Id, r.RoomNo, r.NumOfBeds))
            .ToListAsync();
    }
}
