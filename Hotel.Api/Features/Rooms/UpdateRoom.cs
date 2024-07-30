using Hotel.Api.Utils;

namespace Hotel.Api.Features.Rooms;

public static class UpdateRoom
{
    public record Request(int Id, string RoomNo, int NumOfBeds);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/rooms/{id}", Handler);
        }
    }

    public static async Task<IResult> Handler(int id, Request request, HotelContext db)
    {
        if (id != request.Id) return Results.Conflict();

        var room = await db.Rooms.FindAsync(id);

        if (room is null) return Results.NotFound();

        db.Entry(room).CurrentValues.SetValues(request);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
}
