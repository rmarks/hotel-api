using Carter;

namespace Hotel.Api.Features.Visitors;

public class DeleteVisitorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/visitors/{id}", DeleteVisitor)
            .WithTags("Visitors")
            .Produces(204)
            .Produces(404);
    }

    public async Task<IResult> DeleteVisitor(int id, HotelContext db)
    {
        var visitor = await db.Visitors.FindAsync(id);

        if (visitor is null) return Results.NotFound();

        db.Remove(visitor);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
}
