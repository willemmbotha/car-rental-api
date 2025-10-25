using Car.Rental.Domain.Customers;
using Car.Rental.Domain.Rentals;
using Car.Rental.Domain.Users;
using Car.Rental.Domain.Vehicles;
using Car.Rental.Persistence.Repositories;
using Car.Rental.Persistence.Shared.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Car.Rental.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditInterceptor>();

        var connectionString = configuration.GetConnectionString("DBConnection");
        
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.EnableDynamicJson();

        var dataSource = dataSourceBuilder.Build();
        services.AddDbContext<CrDbContext>((serviceProvider, optionsBuilder) =>
        {
            optionsBuilder.UseNpgsql(dataSource, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CR"));
            optionsBuilder.AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptor>());
        });
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}