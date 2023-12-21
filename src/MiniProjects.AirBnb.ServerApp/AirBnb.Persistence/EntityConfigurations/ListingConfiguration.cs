using AirBnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.Persistence.EntityConfigurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.Property(listing => listing.Name).IsRequired().HasMaxLength(255);

        builder.HasOne<ListingCategory>().WithMany().HasForeignKey(listing => listing.CategoryId);
    }
}