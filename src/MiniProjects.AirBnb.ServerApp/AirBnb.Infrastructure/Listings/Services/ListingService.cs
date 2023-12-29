using System.Linq.Expressions;
using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Listings.Services;
using AirBnb.Domain.Entities;
using AirBnb.Persistence.Repositories.Interfaces;

namespace AirBnb.Infrastructure.Listings.Services;

/// <summary>
/// Provides location category foundation service functionality
/// </summary>
public class ListingService(IListingRepository listingRepository) : IListingService
{
    public IQueryable<Listing> GetAsync(Expression<Func<Listing, bool>>? predicate = default, QueryOptions queryOptions = new()) =>
        listingRepository.Get(predicate, queryOptions.AsNoTracking);
}