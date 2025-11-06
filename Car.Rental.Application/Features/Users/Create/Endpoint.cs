using Car.Rental.Domain.Users;
using FastEndpoints;

namespace Car.Rental.Application.Features.Users.Create;

public class Endpoint(IUserRepository userRepository) : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("create");
        Group<UserGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = Map.ToEntity(req);

        await userRepository.AddAsync(user, ct);
        await userRepository.SaveChangesAsync(ct);

        await Send.OkAsync(new Response(true), ct);
    }
}