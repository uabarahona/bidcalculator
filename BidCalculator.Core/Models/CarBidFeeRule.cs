using BidCalculator.Data.FeeRules;

namespace BidCalculator.Data.Models;
public class CarBidFeeRule
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required CarType Type { get; set; }
    public required IFeeRule FeeRule { get; set; }
}
