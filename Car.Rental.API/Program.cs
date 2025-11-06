using Asp.Versioning;
using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Domain.Shared.UserContext;
using Car.Rental.Persistence.Extensions;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using FastEndpoints.Swagger;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConfiguration")
                       ?? throw new InvalidOperationException("The connection string 'AppConfiguration' was not found.");

builder.Configuration.AddAzureAppConfiguration(connectionString);

builder.Services.AddSerilog();

builder.Services.AddAuthentication()
    .AddJwtBearer("Descope", options =>
    {
        options.Audience = builder.Configuration["Descope:Audience"] ?? throw new InvalidOperationException("The Audience configuration was not found.");
        options.Authority = builder.Configuration["Descope:Authority"] ?? throw new InvalidOperationException("The Authority configuration was not found.");
    });

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

app.UseAuthentication()
    .UseAuthorization()
    .AddApplication()
    .UseSwaggerGen()
    .UseDefaultExceptionHandler();

app.Run();