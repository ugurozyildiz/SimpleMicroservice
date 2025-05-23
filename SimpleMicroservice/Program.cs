using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt
            .WithTitle("WEB API")
            .WithTheme(ScalarTheme.Kepler)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithOpenApiRoutePattern("../openapi/v1.json");
    });
}
else
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt
            .WithTitle("WEB API")
            .WithTheme(ScalarTheme.Kepler)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithOpenApiRoutePattern("../openapi/v1.json");
    });
}

app.MapGet("/", () => "Hello world!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
