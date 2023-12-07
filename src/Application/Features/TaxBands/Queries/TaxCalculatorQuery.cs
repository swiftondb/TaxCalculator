using MediatR;
using TaxCalculator.Application.Features.TaxBands.Dtos;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.Features.TaxBands.Queries;

public record CalculateTaxQuery(decimal GrossAnnualSalary) : IRequest<CalculateTaxResultDto>;

class CalculateTaxHandler : RequestHandler<CalculateTaxQuery, CalculateTaxResultDto>
{
    private readonly IPersistence persistence;

    public CalculateTaxHandler(IPersistence persistence)
    {
        this.persistence = persistence;
    }

    protected override CalculateTaxResultDto Handle(CalculateTaxQuery request)
    {
        // Fetch relevant tax bands
        var taxBands = persistence.Query<TaxBand>()
            .Where(e => e.LowerLimit < request.GrossAnnualSalary)
            .Select(e => new
            {
                e.TaxRate,
                e.LowerLimit,
                e.UpperLimit,
            })
            .OrderBy(e => e.LowerLimit);

        decimal totalAnnualTax = 0M;

        foreach (var band in taxBands)
        {
            decimal effectiveUpperLimit;

            if (band.UpperLimit.HasValue)
            {
                effectiveUpperLimit = Math.Min(band.UpperLimit.Value, request.GrossAnnualSalary);
            }
            else
            {
                effectiveUpperLimit = request.GrossAnnualSalary;
            }

            decimal taxableAmount = effectiveUpperLimit - band.LowerLimit;
            decimal taxForThisBand = (band.TaxRate / 100M) * taxableAmount;

            totalAnnualTax += taxForThisBand;
        }

        decimal netAnnualSalary = request.GrossAnnualSalary - totalAnnualTax;

        return new CalculateTaxResultDto
        {
            GrossAnnualSalary = request.GrossAnnualSalary,
            GrossMonthlySalary = request.GrossAnnualSalary / 12M,
            AnnualTaxPaid = totalAnnualTax,
            MonthlyTaxPaid = totalAnnualTax / 12M,
            NetAnnualSalary = netAnnualSalary,
            NetMonthlySalary = netAnnualSalary / 12M,
        };
    }
}
