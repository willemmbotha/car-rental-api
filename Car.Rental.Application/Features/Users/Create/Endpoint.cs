using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Users.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("create");
        Group<UserGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        // Put on some queue maybe?
        var user = Map.ToEntity(req);
        
        _crDbContext.Users.Add(user);
        await _crDbContext.SaveChangesAsync(ct);
        
        await Send.OkAsync(new Response(true), ct);
    }
}