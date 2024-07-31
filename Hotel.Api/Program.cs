using Hotel.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDal();
builder.Services.AddEndpoints();
builder.Services.AddCors(options => 
    options.AddPolicy(name: "AllOrigins", policy => 
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

var app = builder.Build();

app.UseCors("AllOrigins");

app.MapEndpoints();

using (var scope = app.Services.CreateScope())
{
    SeedData.Seed(scope.ServiceProvider.GetRequiredService<HotelContext>());
}

app.Run();
