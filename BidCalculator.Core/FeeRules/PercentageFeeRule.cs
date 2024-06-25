namespace BidCalculator.Data.FeeRules;

/// <summary>
/// Represent a percentage fee
/// </summary>
public class PercentageFeeRule : IFeeRule
{
    /// <summary>
    /// The percentage fee.
    /// </summary>
    public int PercentageFee { get; set; }

    /// <inheritdoc/>
    public decimal CalculateFee(decimal amount) => amount * PercentageFee / 100;
}
