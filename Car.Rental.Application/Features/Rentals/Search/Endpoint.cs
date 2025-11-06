using Car.Rental.Domain.Rentals;
using Car.Rental.Domain.Shared.Search;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Search;

public class Endpoint(IRentalRepository rentalRepository) : Endpoint<SearchRequest, SearchResponse<Response>>
{
    public override void Configure()
    {
        Post("/search");
        Group<RentalGroup>();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await rentalRepository.SearchRentalsAsync(req, ct);
        var data = result.Data.Select(x => new Response()
        {
            Id = x.Id,
            RentalStatus = x.RentalStatus,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Customer = new CustomerResponse()
            {
                Id = x.CustomerId,
                FirstName = x.Customer.FirstName,
                LastName = x.Customer.LastName
            },
            Vehicle = new VehicleResponse()
            {
                Id = x.VehicleId,
                DisplayName = x.Vehicle.DisplayName
            }
        }).ToList();
        await Send.OkAsync(new SearchResponse<Response>
        {
            Data = data,
            Total = result.Total,
        }, ct);
    }
}