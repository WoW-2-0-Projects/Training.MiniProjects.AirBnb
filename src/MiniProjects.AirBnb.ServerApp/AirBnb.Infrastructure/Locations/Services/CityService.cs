using AirBnb.Application.Locations.Services;
using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Infrastructure.Locations.Services;

/// <summary>
/// Provides city foundation service functionality
/// </summary>
public class CityService(ICityRepository cityRepository) : ICityService
{
    public ValueTask<IList<City>> GetAsync(QuerySpecification<City> querySpecification, CancellationToken cancellationToken = default)
    {
        return cityRepository.GetAsync(querySpecification, cancellationToken);
    }
}