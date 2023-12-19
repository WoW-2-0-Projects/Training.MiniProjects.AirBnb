using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Caching.Brokers;
using AirBnb.Persistence.Caching.Models;
using AirBnb.Persistence.DataContexts;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Persistence.Repositories;

/// <summary>
/// Provides country repository functionalities
/// </summary>
public class CountryRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Country, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), ICountryRepository
{
    public new ValueTask<IList<Country>> GetAsync(QuerySpecification<Country> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}