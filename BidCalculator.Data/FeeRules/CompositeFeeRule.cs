namespace BidCalculator.Data.FeeRules;

/// <summary>
/// Represent a set of fees that works together
/// </summary>
public class CompositeFeeRule : IFeeRule
{
    /// <summary>
    /// Set of rules that will be evaluated to get the final fee
    /// </summary>
    public required IList<IFeeRule> FeeRules { get; set; }

    /// <inheritdoc />
    public decimal CalculateFee(decimal amount) => FeeRules.Sum(rule => rule.CalculateFee(amount));
}
