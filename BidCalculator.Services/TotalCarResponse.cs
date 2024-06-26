using BidCalculator.Data;
using System.Text.Json.Serialization;

namespace BidCalculator.Services;

/// <summary>
/// Represent the total cost of a car along with bid and fees
/// </summary>
public class TotalCarResponse
{
    /// <summary>
    /// Car Type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required CarType CarType { get; set; }

    /// <summary>
    /// Bid amount 
    /// </summary>
    public required decimal BidAmount { get;  set; }

    /// <summary>
    /// Fees associated with the car cost
    /// </summary>
    public required IEnumerable<CarBidFeeResponse> Fees { get;  set; }

    /// <summary>
    /// The total cost of the car
    /// </summary>
    public required decimal TotalCost { get;  set; }
}