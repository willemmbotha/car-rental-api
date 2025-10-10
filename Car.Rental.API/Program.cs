using Car.Rental.Application.Common.Extensions;
using Car.Rental.Application.Common.Shared;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services 
    // .AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens")
    // .AddAuthorization() 
    .AddFastEndpoints(o =>
    {
        o.IncludeAbstractValidators = true;
    })
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Car Rental API";
            s.Version = "v1";
                
        };
    });

builder.Services.AddFusionCache();
// builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddScoped<CurrentUserContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();