using System.Security.Claims;
using Car.Rental.Domain.Shared.UserContext;
using FastEndpoints;

namespace Car.Rental.Application.Shared.Processors;

public sealed class UserContextProcessor : IGlobalPreProcessor
{
    public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
    {
        var descopeUserId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userEmail = context.HttpContext.User.FindFirstValue(ClaimTypes.Email);

        var currentUserContext = context.HttpContext.Resolve<CurrentUserContext>();
        currentUserContext.Email = userEmail ?? string.Empty;
        currentUserContext.DescopeUserId = descopeUserId ?? string.Empty;
    }
}