using FluentValidation;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.Validators;

public class TaxBandValidator : AbstractValidator<TaxBand>
{
    public TaxBandValidator()
    {
        RuleFor(x => x.TaxBandName)
            .MaximumLength(100)
            .WithMessage("Band name must be 100 characters or fewer");

        When(x => x.UpperLimit.HasValue, () =>
        {
            RuleFor(x => x.UpperLimit)
                .GreaterThan(entity => entity.LowerLimit)
                .WithMessage("Upper limit must be greater than lower limit");
        });        
    }
}
