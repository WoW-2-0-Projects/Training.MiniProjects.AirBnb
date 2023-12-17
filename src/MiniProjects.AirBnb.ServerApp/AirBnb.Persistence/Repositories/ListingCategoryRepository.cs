using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Caching.Brokers;
using AirBnb.Persistence.Caching.Models;
using AirBnb.Persistence.DataContexts;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Persistence.Repositories;

/// <summary>
/// Provides listing category repository functionalities.
/// </summary>
public class ListingCategoryRepository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<ListingCategory, AppDbContext>(dbContext, cacheBroker, new CacheEntryOptions()), IListingCategoryRepository
{
    public new ValueTask<IList<ListingCategory>> GetAsync(
        QuerySpecification<ListingCategory> querySpecification,
        CancellationToken cancellationToken = default
    )
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}