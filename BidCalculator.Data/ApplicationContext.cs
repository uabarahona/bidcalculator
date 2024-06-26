using BidCalculator.Data.FeeRules;
using BidCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BidCalculator.Data;
public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<CarBidFeeRule> CarBidFeeRules => Set<CarBidFeeRule>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarBidFeeRule>()
            .Property(properName => properName.FeeRule)
            .HasConversion(
                v => JsonSerializer.Serialize(v, default(JsonSerializerOptions)),
                v => JsonSerializer.Deserialize<IFeeRule>(v, default(JsonSerializerOptions))!
            );
    }
}
