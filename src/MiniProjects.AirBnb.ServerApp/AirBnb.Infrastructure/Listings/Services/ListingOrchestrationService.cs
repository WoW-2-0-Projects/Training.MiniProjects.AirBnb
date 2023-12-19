using AirBnb.Application.Listings.Models;
using AirBnb.Application.Listings.Services;
using AirBnb.Domain.Common.Query;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides listing orchestration service functionalities.
/// </summary>
public class ListingOrchestrationService(IListingService listingService) : IListingOrchestrationService
{
    public async ValueTask<IList<ListingAnalysisDetails>> GetByAvailabilityAsync(
        ListingAvailabilityFilter listingAvailabilityFilter,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var listingQuerySpecification = listingAvailabilityFilter.ToQuerySpecification(asNoTracking);
        var result = await listingService.GetAsync(listingQuerySpecification, cancellationToken);
        return result.Select(
                listing => new ListingAnalysisDetails
                {
                    Listing = listing
                }
            )
            .ToList();
    }
}