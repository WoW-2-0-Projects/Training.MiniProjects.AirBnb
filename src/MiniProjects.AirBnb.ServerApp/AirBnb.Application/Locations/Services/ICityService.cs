using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Locations.Services;

/// <summary>
/// Defines city foundation service functionalities.
/// </summary>
public interface ICityService
{
    /// <summary>
    /// Retrieves a list of cities based on the provided query specification.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching cities.</returns>
    ValueTask<IList<City>> GetAsync(QuerySpecification<City> querySpecification, CancellationToken cancellationToken = default);
}