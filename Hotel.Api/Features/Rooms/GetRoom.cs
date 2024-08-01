using Hotel.Api.Utils;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel.Api.Features.Rooms;

public static class GetRoom
{
    public record Response(int Id, string RoomNo, int NumOfBeds);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/rooms/{id}", Handler)
                .WithTags("Rooms");
        }
    }

    public static async Task<Results<Ok<Response>, NotFound>> Handler(int id, HotelContext db)
    {
        var room = await db.Rooms
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        if (room is null) return TypedResults.NotFound();

        var response = new Response(room.Id, room.RoomNo, room.NumOfBeds);

        return TypedResults.Ok(response);
    }
}
