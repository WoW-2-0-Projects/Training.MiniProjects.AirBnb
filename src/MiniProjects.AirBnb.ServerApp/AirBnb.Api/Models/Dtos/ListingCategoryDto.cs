namespace AirBnb.Api.Models.Dtos;

/// <summary>
/// Represents city data transfer object
/// </summary>
public record ListingCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; init; } = default!;

    public string ImageUrl { get; init; } = default!;
}