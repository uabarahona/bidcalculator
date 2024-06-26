namespace BidCalculator.Data.FeeRules;

/// <summary>
/// Represent a fixed fee to be applied if amount is within range
/// </summary>
public class FixedWithRangeFeeRule : IFeeRule
{
    /// <summary>
    /// The fixed fee to be returned if the criteria is met
    /// </summary>
    public decimal FixedFee { get; set; }

    /// <summary>
    /// The minimum amount (exclusive) for the rule to be applied
    /// </summary>
    public decimal MinimumAmount { get; set; }

    /// <summary>
    /// The maximum amount for the rule to be applied
    /// </summary>
    public decimal MaximumAmount { get; set; }

    /// <inheritdoc/>
    public decimal CalculateFee(decimal amount) => amount > MinimumAmount && amount <= MaximumAmount ? FixedFee : 0m;
}
