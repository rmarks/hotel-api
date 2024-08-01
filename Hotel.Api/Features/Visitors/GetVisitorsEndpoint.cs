using Carter;
using Mapster;

namespace Hotel.Api.Features.Visitors;

public record VisitorListModel(int Id, string Name, string Email);

public class GetVisitorsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/visitors", GetVisitors)
            .WithTags("Visitors");
    }

    public async Task<IEnumerable<VisitorListModel>> GetVisitors(HotelContext db)
    {
        return await db.Visitors
            .AsNoTracking()
            .OrderBy(v => v.FirstName)
                .ThenBy(v => v.LastName)
            .ProjectToType<VisitorListModel>()
            .ToListAsync();
    }
}
