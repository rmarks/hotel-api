using Hotel.Api.Utils;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel.Api.Features.Rooms;

public static class CreateRoom
{
    public record Request(string RoomNo, int NumOfBeds);
    public record Response(int Id, string RoomNo, int NumOfBeds);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/rooms", Handler)
                .WithTags("Rooms");
        }
    }

    public static async Task<Created<Response>> Handler(Request request, HotelContext db)
    {
        var room = request.Adapt<Room>();

        await db.AddAsync(room);
        await db.SaveChangesAsync();

        var response = room.Adapt<Response>();

        return TypedResults.Created($"/api/rooms/{response.Id}", response);
    }
}
