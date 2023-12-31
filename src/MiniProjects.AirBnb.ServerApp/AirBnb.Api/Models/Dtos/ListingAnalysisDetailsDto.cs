using AirBnb.Domain.Common.Entities;

namespace AirBnb.Api.Models.Dtos;

/// <summary>
/// Represents listing analysis details data transfer object
/// </summary>
public class ListingAnalysisDetailsDto
{
    /// <summary>
    /// Gets or sets listing name
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Gets or sets the date when an object was built
    /// </summary>
    public DateOnly BuiltDate { get; init; }

    /// <summary>
    /// Gets or sets the address property.
    /// </summary>
    public ComputedDistance Address { get; init; } = default!;

    /// <summary>
    /// Gets or sets the price per night for the property.
    /// </summary>
    public ComputedMoney PricePerNight { get; init; } = default!;

    /// <summary>
    /// Gets or sets listing images
    /// </summary>
    public IList<string> ImagesUrl { get; init; } = default!;
}