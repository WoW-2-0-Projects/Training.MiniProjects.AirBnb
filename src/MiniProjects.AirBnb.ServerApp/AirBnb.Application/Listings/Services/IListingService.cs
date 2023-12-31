using System.Linq.Expressions;
using AirBnb.Application.Common.Queries.Models;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Listings.Services;

/// <summary>
/// Defines listing foundation service functionalities.
/// </summary>
public interface IListingService
{
    /// <summary>
    /// Retrieves a list of cities based on the provided filter
    /// </summary>
    /// <param name="predicate">The predicate to apply.</param>
    /// <param name="queryOptions">Query options</param>
    /// <returns>Queryable of matching cities.</returns>
    IQueryable<Listing> GetAsync(Expression<Func<Listing, bool>>? predicate = default, QueryOptions queryOptions = new());
}