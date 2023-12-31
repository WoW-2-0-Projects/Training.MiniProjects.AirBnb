namespace AirBnb.Application.Common.Commands.Models;

/// <summary>
/// Represents command options
/// </summary>
public readonly struct CommandOptions
{
    /// <summary>
    /// Determines whether to save command changes or not
    /// </summary>
    public bool SaveChanges { get; init; }
}