using BidCalculator.Data;
using System.ComponentModel.DataAnnotations;

namespace BidCalculator.Services;

public class CarBidRequest
{
    [Range(0 , double.MaxValue)]
    public required decimal BidAmount { get; set; }
    public required CarType CarType { get; set; }
}