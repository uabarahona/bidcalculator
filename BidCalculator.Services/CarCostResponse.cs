using BidCalculator.Data;

namespace BidCalculator.Services;

public class CarCostResponse
{
    public CarType CarType { get; set; }
    public decimal BidAmount { get;  set; }
    public IEnumerable<CarBidFeeResponse> Fees { get;  set; }
    public decimal TotalCost { get;  set; }
}