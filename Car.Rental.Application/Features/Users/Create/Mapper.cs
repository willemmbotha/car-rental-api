using Car.Rental.Domain.Users;
using FastEndpoints;

namespace Car.Rental.Application.Features.Users.Create;

public sealed class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request r)
    {
        return new User
        {
            Email = r.Email,
            FirstName = r.FirstName,
            LastName = r.LastName
        };
    }
}