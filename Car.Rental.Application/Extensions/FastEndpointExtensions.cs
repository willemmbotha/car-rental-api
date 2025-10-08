using System.Text.Json;
using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;

namespace Car.Rental.Application.Extensions;

public static class FastEndpointExtensions
{
    public static WebApplication UseFastEndpoints(this WebApplication app)
    {
         app //  .UseAuthentication()
            // .UseAuthorization()
            .UseFastEndpoints(c =>
            {
                c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                c.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
                c.Endpoints.RoutePrefix = "api";
            })
            .UseSwaggerGen();
         return app;
    }
}