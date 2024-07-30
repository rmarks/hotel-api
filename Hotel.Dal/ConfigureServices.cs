using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Dal;

public static class ConfigureServices
{
    public static IServiceCollection AddDal(this IServiceCollection services)
    {
        services.AddDbContext<HotelContext>(o => o.UseInMemoryDatabase("HotelDb"));
        
        return services;
    }
}
