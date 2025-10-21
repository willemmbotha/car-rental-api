using FastEndpoints;

namespace Car.Rental.Application.Features.Users.Create;

public sealed class Mapper : Mapper<Request, Response, Domain.Users.User>
{
    public override Domain.Users.User ToEntity(Request r)
    {
        return new Domain.Users.User
        {
            Email = r.Email,
            FirstName = r.FirstName,
            LastName = r.LastName
        };
    }
}