using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Listings.Models;
using AirBnb.Application.Listings.Services;
using AirBnb.Domain.Common.Query;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides listing orchestration service functionalities.
/// </summary>
public class ListingOrchestrationService(IListingService listingService) : IListingOrchestrationService
{
    public ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        QueryOptions queryOptions = new QueryOptions(),
        CancellationToken cancellationToken = default
    )
    {
        var listingsInitialQuery = listingService.GetAsync(queryOptions: queryOptions);
    }
}