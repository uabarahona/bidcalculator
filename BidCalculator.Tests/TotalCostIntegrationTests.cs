using BidCalculator.Data;
using BidCalculator.Services;
using System.Net;
using System.Net.Http.Json;

namespace BidCalculator.IntegrationTests;

public class TotalCostIntegrationTests(DistributedApplicationFixture fixture) : IClassFixture<DistributedApplicationFixture>
{
    [Theory]
    [InlineData(398, CarType.Common, 550.76)]
    [InlineData(501, CarType.Common, 671.02)]
    [InlineData(57, CarType.Common, 173.14)]
    [InlineData(1800, CarType.Luxury, 2167)]
    [InlineData(1100, CarType.Common, 1287)]
    [InlineData(1000000, CarType.Luxury, 1040320)]
    public async Task GetTotalCostReturnProperInformation(decimal bidPrice, CarType carType, decimal expectedTotalPrice)
    {
        // Arrange
        var httpClient = fixture.DistributedApplication.CreateHttpClient("bidcalculatorapi");
        var bidRequest = new CarBidRequest()
        {
            BidAmount = bidPrice,
            CarType = carType
        };

        // Act
        var response = await httpClient.PostAsJsonAsync("/totalCost", bidRequest);
        var totalPriceData = await response.Content.ReadFromJsonAsync<TotalCarResponse>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(totalPriceData?.TotalCost, expectedTotalPrice);
    }    
}
