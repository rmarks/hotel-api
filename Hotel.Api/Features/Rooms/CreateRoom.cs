using Hotel.Api.Utils;

namespace Hotel.Api.Features.Rooms;

public static class CreateRoom
{
    public record Request(string RoomNo, int NumOfBeds);
    public record Response(int Id, string RoomNo, int NumOfBeds);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/rooms", Handler);
        }
    }

    public static async Task<IResult> Handler(Request request, HotelContext db)
    {
        var room = new Room
        {
            RoomNo = request.RoomNo,
            NumOfBeds = request.NumOfBeds,
        };

        await db.AddAsync(room);
        await db.SaveChangesAsync();

        var response = new Response(room.Id, room.RoomNo, room.NumOfBeds);

        return Results.Created($"/api/rooms/{response.Id}", response);
    }
}
