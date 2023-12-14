namespace AirBnb.Domain.Common.Caching;

/// <summary>
/// Represents a base class for implementing cache models.
/// </summary>
public abstract class CacheModel
{
    /// <summary>
    /// Gets computed cache key.
    /// </summary>
    public abstract string CacheKey { get; }
}