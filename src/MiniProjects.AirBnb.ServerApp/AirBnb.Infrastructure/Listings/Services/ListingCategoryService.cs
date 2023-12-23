using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Listings.Models;
using AirBnb.Application.Listings.Services;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Extensions;
using AirBnb.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides location category foundation service functionality
/// </summary>
public class ListingCategoryService(IListingCategoryRepository listingCategoryRepository) : IListingCategoryService
{
    public async ValueTask<IList<ListingCategory>> GetAsync(
        ListingCategoryFilter listingCategoryFilter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    )
    {
        return await listingCategoryRepository
            .Get(asNoTracking: queryOptions.AsNoTracking)
            .ApplyPagination(listingCategoryFilter)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}