using AirBnb.Domain.Enums;

namespace AirBnb.Domain.Entities;

/// <summary>
/// Represents a monetary amount.
/// </summary>
public class Money
{
    /// <summary>
    /// Gets or sets the amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    public Currency Currency { get; set; }
}