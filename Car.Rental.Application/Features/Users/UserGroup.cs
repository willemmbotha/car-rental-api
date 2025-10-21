using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Car.Rental.Application.Features.Users;

public sealed class UserGroup : Group
{
    public UserGroup()
    {
        Configure("user", ep =>
        {
            ep.Description(x => x
                .WithTags("User"));
        });
    }
}