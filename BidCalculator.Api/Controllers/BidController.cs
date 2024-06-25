using BidCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BidController(CarBidService _carBidService) : ControllerBase
{
    [HttpPost(Name = "CalculateTotalCarCost")]
    public async Task<ActionResult<CarCostResponse>> CalculateTotalCarCost(CarBidRequest carBidRequest)
    {
        return Ok(await _carBidService.CalculateCarTotalCostAsync(carBidRequest));
    }
}
