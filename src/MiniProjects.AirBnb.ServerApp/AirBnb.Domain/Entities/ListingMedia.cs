using AirBnb.Domain.Common.Entities;

namespace AirBnb.Domain.Entities;

/// <summary>
/// Represents a listing media
/// </summary>
public class ListingMedia : Entity
{
    /// <summary>
    /// Gets or sets listing
    /// </summary>
    public Guid StorageFileId { get; set; }

    /// <summary>
    /// Gets or sets storage file
    /// </summary>
    public StorageFile StorageFile { get; set; } = default!;
}