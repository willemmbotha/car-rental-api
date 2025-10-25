using Car.Rental.Domain.Rentals;
using Car.Rental.Domain.Shared.Search;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Search;

public class Endpoint(IRentalRepository rentalRepository) : Endpoint<SearchRequest, SearchResponse<RentalDto>>
{
    public override void Configure()
    {
        Post("/search");
        Group<RentalGroup>();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await rentalRepository.SearchAsync<RentalDto>(req, ct);
        await Send.OkAsync(result, ct);
    }
}