using Hotel.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDal();
builder.Services.AddEndpoints();

var app = builder.Build();

app.MapEndpoints();

using (var scope = app.Services.CreateScope())
{
    SeedData.Seed(scope.ServiceProvider.GetRequiredService<HotelContext>());
}

app.Run();
