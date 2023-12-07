using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Infrastructure.Contexts.EntityConfigurations;

internal class TaxBandConfiguration : IEntityTypeConfiguration<TaxBand>
{
    public void Configure(EntityTypeBuilder<TaxBand> builder)
    {
        builder.HasIndex(e => e.TaxBandName).IsUnique();

        // Data provided 2023-12-04
        builder.HasData(new[]
        {
            new TaxBand
            {
                Id = 1,
                TaxBandName = "Tax Band A",
                LowerLimit = 0,
                UpperLimit = 5_000,
                TaxRate = 0,
            },
            new TaxBand
            {
                Id = 2,
                TaxBandName = "Tax Band B",
                LowerLimit = 5_000,
                UpperLimit = 20_000,
                TaxRate = 20,
            },
            new TaxBand
            {
                Id = 3,
                TaxBandName = "Tax Band C",
                LowerLimit = 20_000,
                UpperLimit = null, // No upper limit
                TaxRate = 40,
            },
        });
    }
}
