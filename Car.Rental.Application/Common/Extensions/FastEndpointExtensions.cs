using System.Text.Json;
using System.Text.Json.Serialization;
using Car.Rental.Application.Common.Processor;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;

namespace Car.Rental.Application.Common.Extensions;

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
                c.Endpoints.Configurator = ep =>
                {
                    ep.PreProcessor<UserContextProcessor>(Order.Before);
                };
            })
            .UseSwaggerGen();
         return app;
    }
}