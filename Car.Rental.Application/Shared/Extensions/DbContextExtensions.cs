using Car.Rental.Persistence;
using Car.Rental.Persistence.Shared.Interceptors;
using Google.Cloud.SecretManager.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Car.Rental.Application.Shared.Extensions;

public static class DbContextExtensions
{
    public static void AddDbContext(this IServiceCollection services)
    {
        var client = SecretManagerServiceClient.Create();
        var projectId = "cryptic-acrobat-418809";
        var secretId = "PostgressSQLConnectionString";
        var versionId = "latest";
        var secretVersionName = new SecretVersionName(projectId, secretId, versionId);
        var result = client.AccessSecretVersion(secretVersionName);
        var secretValue = result.Payload.Data.ToStringUtf8();

        services.AddScoped<AuditInterceptor>();

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(secretValue);
        dataSourceBuilder.EnableDynamicJson();

        var dataSource = dataSourceBuilder.Build();
        services.AddDbContext<CrDbContext>((serviceProvider, optionsBuilder) =>
        {
            optionsBuilder.UseNpgsql(dataSource, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CR"));
            optionsBuilder.AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptor>());
        });
    }
}