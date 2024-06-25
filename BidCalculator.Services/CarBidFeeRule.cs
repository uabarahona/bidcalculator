using BidCalculator.Data.Models;
namespace BidCalculator.Services;

public static class CarBidFeeRuleProcessor
{
    public static IEnumerable<CarBidFeeResponse> ProcessFees(IList<CarBidFeeRule> feeRules, decimal bidAmount)
    {
        return feeRules.Select(feeRule => new CarBidFeeResponse()
        {
            Title = feeRule.Title,
            Description = feeRule.Description,
            Fee = feeRule.FeeRule.CalculateFee(bidAmount)
        });
    }
}
