using Carter;
using Mapster;

namespace Hotel.Api.Features.Visitors;

public record CreateVisitorModel(string FirstName, string LastName, string IdCode, string Email);

public class CreateVisitorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/visitors", CreateVisitor)
            .WithTags("Visitors")
            .Produces<VisitorModel>(201);
    }

    public async Task<IResult> CreateVisitor(CreateVisitorModel createModel, HotelContext db)
    {
        var visitor = createModel.Adapt<Visitor>();

        await db.AddAsync(visitor);
        await db.SaveChangesAsync();

        var model = visitor.Adapt<VisitorModel>();

        return Results.Created($"/api/visitors/{model.Id}", model);
    }
}
