using BidCalculator.Data;
using BidCalculator.Data.FeeRules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BidCalculator.Api;

public static class ConfigurationExtensions
{
    public async static Task EnsureDatabaseIsProperlyCreated(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Create the database if it does not exist.
            // Do this first so there is then a database to start a transaction against.
            if (!await dbCreator.ExistsAsync())
            {
                await dbCreator.CreateAsync();
            }

            await dbContext.Database.MigrateAsync();

            if (!await dbContext.CarBidFeeRules.AnyAsync())
            {
                await dbContext.CarBidFeeRules.AddRangeAsync([
                    new()
                    {
                        Id = default,
                        Type = CarType.Common,
                        Title = "Basic Fee",
                        Description = "minimum $10 and maximum $50",
                        FeeRule = new PercentageWithMinMaxFeeRule()
                        {
                            PercentageFee = 10,
                            Minimum = 10,
                            Maximum = 50,
                        }
                    },
                    new()
                    {
                        Id = default,
                        Type = CarType.Luxury,
                        Title = "Basic Fee",
                        Description = "minimum 25$ and maximum 200$",
                        FeeRule = new PercentageWithMinMaxFeeRule()
                        {
                            PercentageFee = 10,
                            Minimum = 25,
                            Maximum = 200,
                        }
                    },
                    new()
                    {
                        Id = default,
                        Type = CarType.Common,
                        Title = "Special Fee",
                        Description = "2% of the vehicle price",
                        FeeRule = new PercentageFeeRule()
                        {
                            PercentageFee = 2,
                        }
                    },
                    new()
                    {
                        Id = default,
                        Type = CarType.Luxury,
                        Title = "Special Fee",
                        Description = "4% of the vehicle price",
                        FeeRule = new PercentageFeeRule()
                        {
                            PercentageFee = 4,
                        }
                    },
                    new()
                    {
                        Id = default,
                        Type = CarType.All,
                        Title = "Association fee",
                        Description = "Added costs for the association based on the price of the vehicle",
                        FeeRule = new CompositeFeeRule()
                        {
                            FeeRules =
                            [
                                new FixedWithRangeFeeRule()
                                {
                                    MinimumAmount = 1,
                                    MaximumAmount = 500,
                                    FixedFee = 5
                                },
                                new FixedWithRangeFeeRule()
                                {
                                    MinimumAmount = 500,
                                    MaximumAmount = 1000,
                                    FixedFee = 10
                                },
                                new FixedWithRangeFeeRule()
                                {
                                    MinimumAmount = 1000,
                                    MaximumAmount = 3000,
                                    FixedFee = 15
                                },
                                new FixedForGreaterThanFeeRule()
                                {
                                    MinimumAmount = 3000,
                                    FixedFee = 20
                                }
                            ]
                        }
                    },
                    new()
                    {                        
                        Id = default,
                        Type = CarType.All,
                        Title = "Storage fee",
                        Description = "A fixed storage fee of $100",
                        FeeRule = new FixedFeeRule()
                        {
                            FixedFee = 100
                        }
                    }
                ]);

                await dbContext.SaveChangesAsync();
            }
        });
    }
}
