using Hotel.Api.Utils;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel.Api.Features.Rooms;

public static class UpdateRoom
{
    public record Request(int Id, string RoomNo, int NumOfBeds);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/rooms/{id}", Handler)
                .WithTags("Rooms");
        }
    }

    public static async Task<Results<NoContent, NotFound, Conflict>> Handler(int id, Request request, HotelContext db)
    {
        if (id != request.Id) return TypedResults.Conflict();

        var room = await db.Rooms.FindAsync(id);

        if (room is null) return TypedResults.NotFound();

        db.Entry(room).CurrentValues.SetValues(request);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}
