using BidCalculator.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BidCalculator.Services;

/// <summary>
/// Represent the bid information
/// </summary>
public class CarBidRequest
{
    /// <summary>
    /// Bid amount
    /// </summary>
    [Range(0 , double.MaxValue)]
    public required decimal BidAmount { get; set; }

    /// <summary>
    /// Car type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required CarType CarType { get; set; }
}