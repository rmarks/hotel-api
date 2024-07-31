using Hotel.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDal();
builder.Services.AddEndpoints();
builder.Services.AddCors(options => 
    options.AddPolicy(name: "AllOrigins", policy => 
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddEndpointsApiExplorer();
// because of the structure and naming of classes that contain Room endpoints and records.
// https://stackoverflow.com/questions/56475384/swagger-different-classes-in-different-namespaces-with-same-name-dont-work
// https://stackoverflow.com/questions/65196695/swagger-swashbuckle-does-not-support-nested-class-as-action-method-parameter
builder.Services.AddSwaggerGen(config =>
{
    config.CustomSchemaIds(x => x.FullName?.Replace("+", ".")); // Enables to support different classes with the same name using the full name with namespace
    config.SchemaFilter<NamespaceSchemaFilter>(); // Makes the namespaces hidden for the schemas
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllOrigins");

app.UseSwagger();
app.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1)); // Hides schemas/models section in Swagger UI

app.MapEndpoints();

using (var scope = app.Services.CreateScope())
{
    SeedData.Seed(scope.ServiceProvider.GetRequiredService<HotelContext>());
}

app.Run();
