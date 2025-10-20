using Asp.Versioning;
using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Persistence.Shared.UserContext;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    // .AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens")
    // .AddAuthorization() 
    .AddFastEndpoints(o => { o.IncludeAbstractValidators = true; })
    .AddVersioning(o =>
    {
        o.DefaultApiVersion = new ApiVersion(1.0);
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");
    })
    .SwaggerDocument(o =>
    {
        o.AutoTagPathSegmentIndex = 0;
        o.MaxEndpointVersion = 1;
        o.DocumentSettings = s =>
        {
            s.Title = "Car Rental API";
            s.Version = "v1";
            s.DocumentName = "v1";
            s.MarkNonNullablePropsAsRequired();
        };
    });

builder.Services.AddFusionCache();
builder.Services.AddDbContext();
builder.Services.AddScoped<CurrentUserContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();