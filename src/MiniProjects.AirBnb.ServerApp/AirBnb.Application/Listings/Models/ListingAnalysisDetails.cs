using AirBnb.Domain.Entities;

namespace AirBnb.Application.Listings.Models;

/// <summary>
/// Represents listing analysis details.
/// </summary>
public class ListingAnalysisDetails
{
    /// <summary>
    /// Gets or sets listing
    /// </summary>
    public Listing Listing { get; set; } = default!;
}