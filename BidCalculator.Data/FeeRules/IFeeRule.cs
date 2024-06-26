using System.Text.Json.Serialization;

namespace BidCalculator.Data.FeeRules;

/// <summary>
/// Represent a rule to calculate a fee
/// </summary>
[JsonDerivedType(typeof(FixedFeeRule), typeDiscriminator: "FixedFeeRule")]
[JsonDerivedType(typeof(FixedWithRangeFeeRule), typeDiscriminator: "FixedWithRangeFeeRule")]
[JsonDerivedType(typeof(FixedForGreaterThanFeeRule), typeDiscriminator: "FixedFeeForGreaterThan")]
[JsonDerivedType(typeof(PercentageFeeRule), typeDiscriminator: "PercentageFeeRule")]
[JsonDerivedType(typeof(PercentageWithMinMaxFeeRule), typeDiscriminator: "PercentageWithMinMaxFeeRule")]
[JsonDerivedType(typeof(CompositeFeeRule), typeDiscriminator: "CompositeFeeRule")]
public interface IFeeRule
{
    /// <summary>
    /// Calculate the fee based on the amount
    /// </summary>
    /// <param name="amount">The amount fhe fee will be calculated against</param>
    /// <returns>The fee</returns>
    decimal CalculateFee(decimal amount);
}
