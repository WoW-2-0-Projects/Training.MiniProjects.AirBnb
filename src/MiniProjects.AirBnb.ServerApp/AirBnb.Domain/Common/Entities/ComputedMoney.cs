using AirBnb.Domain.Enums;

namespace AirBnb.Domain.Common.Entities;

/// <summary>
/// Represents money data transfer object
/// </summary>
public class ComputedMoney
{
    /// <summary>
    /// Gets or sets money amount
    /// </summary>
    public decimal CalculatedAmount { get; init; }

    /// <summary>
    /// Gets or sets currency
    /// </summary>
    public Currency UserCurrency { get; init; }
}