using AirBnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<City> Cities => Set<City>();

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<StorageFile> StorageFiles => Set<StorageFile>();

    // public DbSet<ListingCategory> ListingCategories => Set<ListingCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}