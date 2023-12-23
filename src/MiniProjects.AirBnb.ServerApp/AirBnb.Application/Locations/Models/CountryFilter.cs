using AirBnb.Domain.Common.Query;

namespace AirBnb.Application.Locations.Models;

/// <summary>
/// Represents a country filter
/// </summary>
public class CountryFilter : FilterPagination
{
    /// <summary>
    /// Gets the search keyword for country filtering
    /// </summary>
    public string? SearchKeyword { get; init; }

    public bool IncludeCities { get; set; }
}