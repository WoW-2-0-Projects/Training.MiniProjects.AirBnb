using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Caching.Brokers;
using AirBnb.Persistence.Caching.Models;
using AirBnb.Persistence.DataContexts;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Persistence.Repositories;

/// <summary>
/// Provides listing repository functionalities
/// </summary>
public class ListingRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Listing, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), IListingRepository
{
    public new ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}