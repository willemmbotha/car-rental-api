using Car.Rental.Domain.Customers;
using Car.Rental.Domain.Shared.Search;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Search;

public class Endpoint(ICustomerRepository customerRepository) : Endpoint<SearchRequest, SearchResponse<CustomerDto>>
{
    public override void Configure()
    {
        Post("/search");
        Group<CustomerGroup>();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await customerRepository.SearchAsync<CustomerDto>(req, ct);

        await Send.OkAsync(result, ct);
    }
}