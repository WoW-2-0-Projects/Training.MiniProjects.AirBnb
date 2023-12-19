namespace AirBnb.Domain.Entities;

/// <summary>
/// Represents city as a location
/// </summary>
public class City : Location
{
    /// <summary>
    /// Gets or sets the ID of the parent.
    /// </summary>
    public Guid? ParentId { get; set; }
}