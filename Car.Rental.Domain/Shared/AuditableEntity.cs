namespace Car.Rental.Domain.Shared;

public abstract class AuditableEntity
{
    public long Id { get; set; }
    
    public string CreatedBy { get; set; } = null!;
    public DateTimeOffset CreatedDate { get; set; }
    
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool? IgnoreSoftDelete { get; set; }
    
    public uint RowVersion { get; set; }
}