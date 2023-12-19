using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines city repository functionalities
/// </summary>
public interface ICityRepository
{
    /// <summary>
    /// Retrieves a list of cities based on the specified query specification asynchronously.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching cities.</returns>
    ValueTask<IList<City>> GetAsync(QuerySpecification<City> querySpecification, CancellationToken cancellationToken = default);
}