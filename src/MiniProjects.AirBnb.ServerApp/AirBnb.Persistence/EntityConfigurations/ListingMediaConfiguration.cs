using AirBnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.Persistence.EntityConfigurations;

public class ListingMediaConfiguration : IEntityTypeConfiguration<ListingMedia>
{
    public void Configure(EntityTypeBuilder<ListingMedia> builder)
    {
        builder
            .HasOne(listingMedia => listingMedia.StorageFile)
            .WithOne()
            .HasForeignKey<ListingMedia>(listingMedia => listingMedia.StorageFileId);
        
        builder
            .HasOne(listingMedia => listingMedia.Listing)
            .WithMany(listingMedia => listingMedia.ImagesStorageFile)
            .HasForeignKey(listingMedia => listingMedia.ListingId);
    }
}