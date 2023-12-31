using AirBnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.Persistence.EntityConfigurations;

public class StorageFileConfiguration : IEntityTypeConfiguration<StorageFile>
{
    public void Configure(EntityTypeBuilder<StorageFile> builder)
    {
        builder.Property(e => e.FileName).HasMaxLength(255).IsRequired();
    }
}