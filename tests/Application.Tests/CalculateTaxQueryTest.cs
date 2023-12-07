using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Application.Features.TaxBands.Dtos;
using TaxCalculator.Application.Features.TaxBands.Queries;

namespace TaxCalculator.Application.Tests;

public class CalculateTaxQueryTest : TestsBase
{
    [Theory]
    [InlineData(5_000, 0, 0)]
    [InlineData(10_000, 1_000, 83.3333)]
    [InlineData(20_000, 3_000, 250)]
    [InlineData(40_000, 11_000, 916.6667)]
    public async Task CalculateTax(decimal grossAnnualSalary, decimal expectedAnnualTaxPaid, decimal expectedMonthlyTaxPaid)
    {
        // arrange
        ISender sender = ServiceProvider.GetRequiredService<ISender>();
        CalculateTaxQuery query = new(grossAnnualSalary);

        // act
        CalculateTaxResultDto result = await sender.Send(query);

        // assert
        Assert.Equal(expectedAnnualTaxPaid, result.AnnualTaxPaid, 4);
        Assert.Equal(expectedMonthlyTaxPaid, result.MonthlyTaxPaid, 4);
    }
}
