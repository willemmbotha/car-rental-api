using Microsoft.Extensions.Configuration;

namespace Car.Rental.Application.Common.Shared;

public class AppConfiguration : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new SecretManagerConfigurationProvider();
    }
}

public class SecretManagerConfigurationProvider : ConfigurationProvider;


