namespace Car.Rental.Application.Shared.Search;

public sealed class SearchResponse<T>
{
    public int Total { get; set; }
    public List<T> Data { get; set; } = [];
}