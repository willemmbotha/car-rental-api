using System.Text.Json;
using System.Text.Json.Serialization;
using Car.Rental.Application.Shared.Processors;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;

namespace Car.Rental.Application.Shared.Extensions;

public static class FastEndpointExtensions
{
    public static WebApplication UseFastEndpoints(this WebApplication app)
    {
        app //  .UseAuthentication()
            // .UseAuthorization()
            .UseFastEndpoints(c =>
            {
                c.Endpoints.RoutePrefix = "api";
                c.Versioning.Prefix = "v";
                c.Versioning.DefaultVersion = 1;
                c.Versioning.PrependToRoute = true;

                c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                c.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
                c.Serializer.Options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                c.Serializer.Options.WriteIndented = true;

                c.Endpoints.Configurator = ep => { ep.PreProcessor<UserContextProcessor>(Order.Before); };
                c.Errors.UseProblemDetails();
            })
            .UseSwaggerGen()
            .UseDefaultExceptionHandler();
        return app;
    }
}