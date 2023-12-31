using AirBnb.Domain.Common.Query;
using AirBnb.Domain.Entities;

namespace AirBnb.Application.Listings.Models;

/// <summary>
/// Represents listing availability filter
/// </summary>
public class ListingAvailabilityFilter : FilterPagination
{
    /// <summary>
    /// Gets the availability start date
    /// </summary>
    public DateOnly StartDate { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// Gets the listing category Id
    /// </summary>
    public Guid CategoryId { get; init; }
}