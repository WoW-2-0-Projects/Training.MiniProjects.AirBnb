using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Listings.Services;

/// <summary>
/// Defines location category foundation service functionalities.
/// </summary>
public interface IListingCategoryService
{
    /// <summary>
    /// Retrieves a list of locations categories based on the provided query specification.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching listing categories.</returns>
    ValueTask<IList<ListingCategory>> GetAsync(QuerySpecification<ListingCategory> querySpecification, CancellationToken cancellationToken = default);
}