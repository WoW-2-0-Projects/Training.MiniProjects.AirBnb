﻿using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Enums;

namespace AirBnb.Domain.Entities;

/// <summary>
/// Represents a storage file.
/// </summary>
public class StorageFile : Entity
{
    /// <summary>
    /// Gets or sets the file name.
    /// </summary>
    public string FileName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the type of storage file.
    /// </summary>
    public StorageFileType Type { get; set; }
}