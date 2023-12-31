namespace AirBnb.Api.Models.Dtos;

/// <summary>
/// Represents city data transfer object
/// </summary>
public record ListingCategoryDto
{
    /// <summary>
    /// Gets the image url of the listing category.
    /// </summary>
    public string ImageUrl { get; init; } = default!;
}