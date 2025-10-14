using Car.Rental.Domain.Customers;
using Car.Rental.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Persistence.Configurations;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ConfigureAuditFields();

        builder.ToTable(nameof(Customer));
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(CustomerConstants.FirstNameMaxLength);
        
        builder.Property(x => x.LastName)
            .HasMaxLength(CustomerConstants.LastNameMaxLength);
        
        builder.Property(x => x.Email)
            .HasMaxLength(CustomerConstants.EmailMaxLength);
        
        builder.Property(x => x.Address)
            .HasMaxLength(CustomerConstants.AddressMaxLength);
    }
}