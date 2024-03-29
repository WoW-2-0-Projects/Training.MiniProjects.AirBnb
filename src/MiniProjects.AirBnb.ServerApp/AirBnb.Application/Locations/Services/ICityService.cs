﻿using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Locations.Models;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Locations.Services;

/// <summary>
/// Defines city foundation service functionalities.
/// </summary>
public interface ICityService
{
    /// <summary>
    /// Retrieves a list of cities based on the provided filter
    /// </summary>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="queryOptions">Query options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching cities.</returns>
    ValueTask<IList<City>> GetAsync(CityFilter filter, QueryOptions queryOptions = new(), CancellationToken cancellationToken = default);
}