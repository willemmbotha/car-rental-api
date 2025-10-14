using Car.Rental.Persistence.Common.UserContext;
using FastEndpoints;

namespace Car.Rental.Application.Shared.Processors;

public sealed class UserContextProcessor : IGlobalPreProcessor
{
    public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
    {
        var currentUserContext = context.HttpContext.Resolve<CurrentUserContext>();
        currentUserContext.Username = "Car.Rental.API";
    }
}