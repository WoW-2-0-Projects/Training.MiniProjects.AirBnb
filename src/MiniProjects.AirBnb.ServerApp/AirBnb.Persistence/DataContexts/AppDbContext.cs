using AirBnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Location> Locations => Set<Location>();
    
    public DbSet<StorageFile> StorageFiles => Set<StorageFile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}