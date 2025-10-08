using Car.Rental.Application.Extensions;
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
    .SwaggerDocument((o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "EG API";
            s.Version = "v1";
                
        };
    }));

builder.Services.AddFusionCache();
builder.Services.AddDbContext();

var app = builder.Build();

app.UseHttpsRedirection();
MainExtensions.UseFastEndpoints(app);

app.Run();