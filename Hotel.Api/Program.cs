using Hotel.Dal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDal();

var app = builder.Build();

app.MapGet("/", (HotelContext db) => $"Rooms in Hotel: {db.Rooms.Count()}");

using (var scope = app.Services.CreateScope())
{
    SeedData.Seed(scope.ServiceProvider.GetRequiredService<HotelContext>());
}

app.Run();
