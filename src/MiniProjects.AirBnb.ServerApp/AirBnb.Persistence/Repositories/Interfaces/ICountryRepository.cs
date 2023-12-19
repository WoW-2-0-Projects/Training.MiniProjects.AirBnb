using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines country repository functionalities
/// </summary>
public interface ICountryRepository
{
    /// <summary>
    /// Retrieves a list of countries based on the specified query specification asynchronously.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching countries.</returns>
    ValueTask<IList<Country>> GetAsync(QuerySpecification<Country> querySpecification, CancellationToken cancellationToken = default);
}