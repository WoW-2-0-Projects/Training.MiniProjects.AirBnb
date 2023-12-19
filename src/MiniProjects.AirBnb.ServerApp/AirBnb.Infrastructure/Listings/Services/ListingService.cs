using AirBnb.Application.Listings.Services;
using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides location category foundation service functionality
/// </summary>
public class ListingService(IListingRepository listingRepository) : IListingService
{
    public ValueTask<IList<Listing>> GetAsync(QuerySpecification<Listing> querySpecification, CancellationToken cancellationToken = default)
    {
        return listingRepository.GetAsync(querySpecification, cancellationToken);
    }
}