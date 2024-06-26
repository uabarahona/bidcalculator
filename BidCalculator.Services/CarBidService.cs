using BidCalculator.Data;
using Microsoft.EntityFrameworkCore;

namespace BidCalculator.Services;

/// <summary>
/// Provide functionalities related with a bid
/// </summary>
/// <param name="applicationContext"></param>
public class CarBidService(ApplicationContext applicationContext)
{
    /// <summary>
    /// Get the total cost including additional fees
    /// </summary>
    /// <param name="carBidRequest">Information about the bid</param>
    /// <returns>Return the total cost along with fees</returns>
    public async Task<TotalCarResponse> CalculateCarTotalCostAsync(CarBidRequest carBidRequest)
    {
        var applicableFeeRules = await applicationContext.CarBidFeeRules
            .Where(rule => rule.Type == carBidRequest.CarType || rule.Type == CarType.All)
            .ToListAsync();

        var fees = CarBidFeeRuleProcessor.ProcessFees(applicableFeeRules, carBidRequest.BidAmount);
        var totalFees = fees.Sum(fee => fee.Fee);

        return new()
        {
            CarType = carBidRequest.CarType,
            BidAmount = carBidRequest.BidAmount,
            Fees = fees,
            TotalCost = carBidRequest.BidAmount + totalFees
        };
    }
}
