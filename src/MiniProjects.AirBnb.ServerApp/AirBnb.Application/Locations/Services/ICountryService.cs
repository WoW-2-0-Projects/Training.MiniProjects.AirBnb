using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Locations.Services;

/// <summary>
/// Defines country foundation service functionalities.
/// </summary>
public interface ICountryService
{
    /// <summary>
    /// Retrieves a list of countries based on the provided query specification.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching locations.</returns>
    ValueTask<IList<Country>> GetAsync(QuerySpecification<Country> querySpecification, CancellationToken cancellationToken = default);
}