using Car.Rental.Persistence;
using Car.Rental.Persistence.Common.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Car.Rental.Application.Common.Extensions;

public static class DbContextExtensions
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        
        // var instance = Google.Api.Gax.Platform.Instance();
        // SecretManagerServiceClient client = SecretManagerServiceClient.Create();
        // string projectId = "cryptic-acrobat-418809";
        // string secretId = "PostgressSQLConnectionString";
        // string versionId = "latest";
        // SecretVersionName secretVersionName = new SecretVersionName(projectId, secretId, versionId);
        // AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);
        // string secretValue = result.Payload.Data.ToStringUtf8();
        
        services.AddScoped<AuditInterceptor>();

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("Database"));
        dataSourceBuilder.EnableDynamicJson();

        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<CrDbContext>((serviceProvider, optionsBuilder) =>
        {
            optionsBuilder.UseNpgsql(dataSource,
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CR"));
            optionsBuilder.AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptor>());
        });
    }
}