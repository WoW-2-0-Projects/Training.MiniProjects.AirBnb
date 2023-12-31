using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Listings.Models;

namespace AirBnb.Application.Listings.Services;

/// <summary>
/// Defines listing orchestration service functionalities.
/// </summary>
public interface IListingOrchestrationService
{
    /// <summary>
    /// Retrieves a list of listings and availability details based on the provided query specification.
    /// </summary>
    /// <param name="listingAvailabilityFilter">Filter being used to query</param>
    /// <param name="queryOptions">Query options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching listings including availability data.</returns>
    ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    );
}