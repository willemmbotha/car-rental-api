using Asp.Versioning;
using Azure.Identity;
using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Domain.Shared.UserContext;
using Car.Rental.Persistence.Extensions;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConfiguration")
                          ?? throw new InvalidOperationException("The connection string 'AppConfiguration' was not found.");

builder.Configuration.AddAzureAppConfiguration(connectionString);

builder.Services.AddAuthorization()
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
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<CurrentUserContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication()
    .UseAuthorization()
    .AddApplication()
    .UseSwaggerGen()
    .UseDefaultExceptionHandler();

app.Run();