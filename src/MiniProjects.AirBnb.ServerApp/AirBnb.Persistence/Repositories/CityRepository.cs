using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Caching.Brokers;
using AirBnb.Persistence.Caching.Models;
using AirBnb.Persistence.DataContexts;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Persistence.Repositories;

/// <summary>
/// Provides city repository functionalities
/// </summary>
public class CityRepository(AppDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<City, AppDbContext>(
    dbContext,
    cacheBroker,
    new CacheEntryOptions()
), ICityRepository
{
    public new ValueTask<IList<City>> GetAsync(QuerySpecification<City> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}