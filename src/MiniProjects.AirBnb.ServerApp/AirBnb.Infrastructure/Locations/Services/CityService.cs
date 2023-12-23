using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Locations.Models;
using AirBnb.Application.Locations.Services;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Extensions;
using AirBnb.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Infrastructure.Locations.Services;

/// <summary>
/// Provides city foundation service functionality
/// </summary>
public class CityService(ICityRepository cityRepository) : ICityService
{
    public async ValueTask<IList<City>> GetAsync(CityFilter filter, QueryOptions queryOptions = new(), CancellationToken cancellationToken = default)
    {
        var initialQuery = cityRepository.Get(asNoTracking: queryOptions.AsNoTracking);

        if (filter.SearchKeyword is not null)
            initialQuery = initialQuery.Where(city => city.Name.ToLower().Contains(filter.SearchKeyword.ToLower()));

        initialQuery = initialQuery.ApplyPagination(filter);

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }
}