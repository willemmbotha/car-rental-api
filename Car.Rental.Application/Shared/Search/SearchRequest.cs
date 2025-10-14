namespace Car.Rental.Application.Shared.Search;

public class SearchRequest
{
    public List<Filter> Filters { get; set; } = [];
    public string LogicalOperator { get; set; } = "|";
    public List<Order> OrderBy { get; set; } = [];
    public int Page { get; set; } 
    public int PageSize { get; set; }
}

public class Filter
{
    public string PropertyName { get; set; } = null!;
    public string Operator { get; set; } = null!;
    public string Value { get; set; } = null!;
}

public class Order
{
    public string PropertyName { get; set; } = null!;
    public string Direction { get; set; } = null!;
}