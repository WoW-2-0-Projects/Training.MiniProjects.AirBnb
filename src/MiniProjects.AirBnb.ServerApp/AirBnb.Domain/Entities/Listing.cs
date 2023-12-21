using AirBnb.Domain.Common.Entities;

namespace AirBnb.Domain.Entities;

/// <summary>
/// Represents a listing for a property
/// </summary>
public class Listing : Entity
{
    /// <summary>
    /// Gets or sets listing name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the date when an object was built
    /// </summary>
    public DateOnly BuiltDate { get; set; } = default!;

    /// <summary>
    /// Gets or sets listing category Id
    /// </summary>
    public Guid CategoryId { get; set; }
}