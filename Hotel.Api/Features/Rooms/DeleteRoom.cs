using Hotel.Api.Utils;

namespace Hotel.Api.Features.Rooms;

public static class DeleteRoom
{
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/rooms/{id}", Handler);
        }
    }

    public static async Task<IResult> Handler(int id, HotelContext db)
    {
        var room = await db.Rooms.FindAsync(id);

        if (room is null) return Results.NotFound();

        db.Remove(room);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
}
