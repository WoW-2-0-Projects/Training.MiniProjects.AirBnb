namespace AirBnb.Domain.Common.Entities;

/// <summary>
/// Represents distance data transfer object
/// </summary>
public class ComputedDistance
{
    /// <summary>
    /// Gets address display name
    /// </summary>
    public string DisplayAddress { get; init; } = default!;

    /// <summary>
    /// Gets calculated distance from user
    /// </summary>
    public int DistanceFromUserInKm { get; init; }
}