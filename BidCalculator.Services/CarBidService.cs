using BidCalculator.Data;
using Microsoft.EntityFrameworkCore;

namespace BidCalculator.Services;

public class CarBidService(ApplicationContext applicationContext)
{
    public async Task<CarCostResponse> CalculateCarTotalCostAsync(CarBidRequest carBidRequest)
    {
        var applicableFeeRules = await applicationContext.CarBidFeeRules
            .Where(rule => rule.Type == carBidRequest.CarType)
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
