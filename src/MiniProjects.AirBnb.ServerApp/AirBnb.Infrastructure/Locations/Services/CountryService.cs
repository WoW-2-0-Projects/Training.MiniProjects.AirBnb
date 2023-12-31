using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Locations.Models;
using AirBnb.Application.Locations.Services;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Extensions;
using AirBnb.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Infrastructure.Locations.Services;

/// <summary>
/// Provides country foundation service functionality
/// </summary>
public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async ValueTask<IList<Country>> GetAsync(
        CountryFilter filter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = countryRepository.Get(asNoTracking: queryOptions.AsNoTracking);

        if (filter.IncludeCities)
            initialQuery = initialQuery.Include(country => country.Cities);

        if (filter.SearchKeyword is not null)
            initialQuery = initialQuery.Where(country => country.Name.ToLower().Contains(filter.SearchKeyword.ToLower()));

        initialQuery = initialQuery.ApplyPagination(filter);

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }
}