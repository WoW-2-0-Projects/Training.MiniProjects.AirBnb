using AirBnb.Application.Locations.Services;
using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Infrastructure.Locations.Services;

/// <summary>
/// Provides country foundation service functionality
/// </summary>
public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public ValueTask<IList<Country>> GetAsync(QuerySpecification<Country> querySpecification, CancellationToken cancellationToken = default)
    {
        return countryRepository.GetAsync(querySpecification, cancellationToken);
    }
}