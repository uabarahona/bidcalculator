using BidCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BidController(CarBidService _carBidService) : ControllerBase
{
    /// <summary>
    /// Calculates the total cost including fees
    /// </summary>
    /// <param name="carBidRequest">The bid information</param>
    /// <returns>The total cost along with fees</returns>
    [HttpPost("/bids/totalCost", Name = "CalculateTotalCarCost")]
    public async Task<ActionResult<TotalCarResponse>> CalculateTotalCarCost(CarBidRequest carBidRequest)
    {
        return Ok(await _carBidService.CalculateCarTotalCostAsync(carBidRequest));
    }
}
