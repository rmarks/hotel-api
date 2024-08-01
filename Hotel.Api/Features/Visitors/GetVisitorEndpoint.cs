using Carter;
using Mapster;

namespace Hotel.Api.Features.Visitors;

public class GetVisitorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/visitors/{id}", GetVisitor)
            .WithTags("Visitors")
            .Produces<VisitorModel>(200)
            .Produces(404);
    }

    public async Task<IResult> GetVisitor(int id, HotelContext db)
    {
        var visitor = await db.Visitors
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == id);

        return visitor is not null
            ? Results.Ok(visitor.Adapt<VisitorModel>())
            : Results.NotFound();
    }
}
