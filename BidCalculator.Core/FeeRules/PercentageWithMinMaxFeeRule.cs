namespace BidCalculator.Data.FeeRules;

/// <summary>
/// Represent a percentage fee that has a minimum and a maximum amount
/// </summary>
public class PercentageWithMinMaxFeeRule : IFeeRule
{
    /// <summary>
    /// The percentage fee.
    /// </summary>
    public int PercentageFee { get; set; }

    /// <summary>
    /// Minimum amount to be set if the percentage fee is less.
    /// </summary>
    public decimal Minimum { get; set; }

    /// <summary>
    /// Maximum amount to be set if the percentage fee is greater.
    /// </summary>
    public decimal Maximum { get; set; }

    /// <inheritdoc/>
    public decimal CalculateFee(decimal amount)
    {
        var fee = amount * PercentageFee / 100;

        return fee switch
        {
            _ when fee < Minimum => Minimum,
            _ when fee > Maximum => Maximum,
            _ => fee
        };
    }
}
