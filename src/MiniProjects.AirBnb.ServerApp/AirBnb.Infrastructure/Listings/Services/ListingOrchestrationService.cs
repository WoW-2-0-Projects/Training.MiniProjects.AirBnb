using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Listings.Models;
using AirBnb.Application.Listings.Services;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides listing orchestration service functionalities.
/// </summary>
public class ListingOrchestrationService(IListingService listingService) : IListingOrchestrationService
{
    public async ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        QueryOptions queryOptions = new QueryOptions(),
        CancellationToken cancellationToken = default
    )
    {
        var listingsInitialQuery = listingService.GetAsync(listing => listing.CategoryId == listingAvailabilityFilter.CategoryId, queryOptions);

        return await listingsInitialQuery.Select(
                listing => new ListingAnalysisDetails
                {
                    Listing = listing
                }
            )
            .ToListAsync(cancellationToken: cancellationToken);
    }
}