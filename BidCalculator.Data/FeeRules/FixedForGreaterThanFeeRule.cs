namespace BidCalculator.Data.FeeRules;
public class FixedForGreaterThanFeeRule : IFeeRule
{
    /// <summary>
    /// The fixed fee to be returned if the criteria is met
    /// </summary>
    public decimal FixedFee { get; set; }

    /// <summary>
    /// The minimum amount (exclusive) for the rule to be applied
    /// </summary>
    public decimal MinimumAmount { get; set; }


    /// <inheritdoc />
    public decimal CalculateFee(decimal amount) => amount > MinimumAmount ? FixedFee : 0m;
}
