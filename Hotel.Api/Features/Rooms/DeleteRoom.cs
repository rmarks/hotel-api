using Hotel.Api.Utils;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel.Api.Features.Rooms;

public static class DeleteRoom
{
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/rooms/{id}", Handler)
                .WithTags("Rooms");
        }
    }

    public static async Task<Results<NoContent, NotFound>> Handler(int id, HotelContext db)
    {
        var room = await db.Rooms.FindAsync(id);

        if (room is null) return TypedResults.NotFound();

        db.Remove(room);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}
