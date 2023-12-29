using System.Linq.Expressions;
using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines storage file repository functionalities
/// </summary>
public interface IListingCategoryRepository
{
    /// <summary>
    /// Retrieves a list of listing categories based on predicate
    /// </summary>
    /// <param name="predicate">Predicate of query to be applied as filter</param>
    /// <param name="asNoTracking">Determines whether to track the query result or not </param>
    /// <returns>A list of listing categories that match the given predicate.</returns>
    IQueryable<ListingCategory> Get(Expression<Func<ListingCategory, bool>>? predicate = null, bool asNoTracking = false);
}