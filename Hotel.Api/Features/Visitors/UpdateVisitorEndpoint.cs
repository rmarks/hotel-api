using Carter;
using Mapster;

namespace Hotel.Api.Features.Visitors;

public class UpdateVisitorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/visitors/{id}", UpdateVisitor)
            .WithTags("Visitors")
            .Produces(204)
            .Produces(404)
            .Produces(409);
    }

    public async Task<IResult> UpdateVisitor(int id, VisitorModel model, HotelContext db)
    {
        if (id != model.Id) return Results.Conflict();

        var visitor = await db.Visitors.FindAsync(id);
        
        if (visitor is null) return Results.NotFound();

        model.Adapt(visitor);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
}
