using Microsoft.Extensions.Configuration;

namespace Car.Rental.Application.Shared.Configuration;

public class AppConfiguration : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new SecretManagerConfigurationProvider();
    }
}

public class SecretManagerConfigurationProvider : ConfigurationProvider;


