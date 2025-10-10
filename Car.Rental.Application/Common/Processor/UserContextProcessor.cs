using Car.Rental.Application.Common.Shared;
using FastEndpoints;

namespace Car.Rental.Application.Common.Processor;

public sealed class UserContextProcessor : IGlobalPreProcessor
{
    
    public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
    {
        var currentUserContext = context.HttpContext.Resolve<CurrentUserContext>();
        currentUserContext.Username = "Car.Rental.API";
    }
}