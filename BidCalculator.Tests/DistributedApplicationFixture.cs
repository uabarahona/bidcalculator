namespace BidCalculator.IntegrationTests;
public class DistributedApplicationFixture : IAsyncLifetime
{
    public DistributedApplication DistributedApplication { get; set; } = null!;

    public async Task InitializeAsync()
    {
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.BidCalculator_AppHost>();

        DistributedApplication = await appHost.BuildAsync();
        await DistributedApplication.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await DistributedApplication.DisposeAsync();
    }
}
