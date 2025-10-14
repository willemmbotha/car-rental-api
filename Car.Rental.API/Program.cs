using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Persistence.Common.UserContext;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    // .AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens")
    // .AddAuthorization() 
    .AddFastEndpoints(o => { o.IncludeAbstractValidators = true; })
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Car Rental API";
            s.Version = "v1";
        };
    });

builder.Services.AddFusionCache();
builder.Services.AddDbContext();
builder.Services.AddScoped<CurrentUserContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();