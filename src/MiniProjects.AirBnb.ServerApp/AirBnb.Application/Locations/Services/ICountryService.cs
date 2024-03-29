﻿using AirBnb.Application.Common.Queries.Models;
using AirBnb.Application.Locations.Models;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Locations.Services;

/// <summary>
/// Defines country foundation service functionalities.
/// </summary>
public interface ICountryService
{
    /// <summary>
    /// Retrieves a list of countries based on the provided filter
    /// </summary>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="queryOptions">Query options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Collection of matching countries.</returns>
    ValueTask<IList<Country>> GetAsync(
        CountryFilter filter,
        QueryOptions queryOptions = new(),
        CancellationToken cancellationToken = default
    );
}