using Carter;

namespace Hotel.Api.Features.Visitors;

public record VisitorListDto(int Id, string Name, string Email);

public class GetVisitorsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/visitors", GetVisitors)
            .WithTags("Visitors");
    }

    public async Task<IEnumerable<VisitorListDto>> GetVisitors(HotelContext db)
    {
        return await db.Visitors
            .AsNoTracking()
            .Select(v => new VisitorListDto(v.Id, v.Name, v.Email))
            .ToListAsync();
    }
}
