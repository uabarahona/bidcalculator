namespace BidCalculator.Data.FeeRules;
/// <summary>
/// Represent a fixed fee
/// </summary>
public class FixedFeeRule : IFeeRule
{
    /// <summary>
    /// The fixed fee to be returned
    /// </summary>
    public int FixedFee { get; set; }

    /// <inheritdoc />
    public decimal CalculateFee(decimal _) => FixedFee;
}
