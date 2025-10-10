namespace Car.Rental.Persistence.Common.Shared;

public abstract class AuditableEntity
{
    public string CreatedBy { get; set; } = null!;
    public DateTimeOffset CreatedDate { get; set; }
    
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}