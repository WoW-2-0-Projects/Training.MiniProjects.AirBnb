using AirBnb.Application.Listings.Services;
using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides location category foundation service functionality
/// </summary>
public class ListingCategoryService(IListingCategoryRepository listingCategoryRepository) : IListingCategoryService
{
    public ValueTask<IList<ListingCategory>> GetAsync(
        QuerySpecification<ListingCategory> querySpecification,
        CancellationToken cancellationToken = default
    )
    {
        return listingCategoryRepository.GetAsync(querySpecification, cancellationToken);
    }
}