using System.Text;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Google.Protobuf;
using Microsoft.Extensions.DependencyInjection;

namespace Car.Rental.Application.Extensions;

public static class DbContextExtensions
{
    public static void AddDbContext(this IServiceCollection serviceCollection)
    {
        SecretManagerServiceClient client = SecretManagerServiceClient.Create();
        ProjectName projectName = new ProjectName("cryptic-acrobat-418809");
        
        foreach (Secret secret in client.ListSecrets(projectName))
        {
            SecretPayload payload = new SecretPayload
            {
                Data = ByteString.CopyFrom("my super secret data", Encoding.UTF8),
            };
            
            SecretVersion createdVersion = client.AddSecretVersion(secret.SecretName, payload);
            
            var result = client.GetSecret(secret.SecretName);
            string data = result.
        }
    }
}