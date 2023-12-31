using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Enums;

namespace AirBnb.Domain.Entities;

/// <summary>
/// Represents unit of location 
/// </summary>
public abstract class Location : Entity
{
    /// <summary>
    /// Gets or sets location name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets location type
    /// </summary>
    public LocationType Type { get; set; }
}