using System.Linq.Expressions;
using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines listing repository functionalities
/// </summary>
public interface IListingRepository
{
    /// <summary>
    /// Retrieves a list of listings based on predicate
    /// </summary>
    /// <param name="predicate">Predicate of query to be applied as filter</param>
    /// <param name="asNoTracking">Determines whether to track the query result or not </param>
    /// <returns>A list of listings that match the given predicate.</returns>
    IQueryable<Listing> Get(Expression<Func<Listing, bool>>? predicate = null, bool asNoTracking = false);
}