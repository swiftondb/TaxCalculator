using FluentValidation;

namespace TaxCalculator.Blazor.Models;

public record SalaryInputModel
{
    public decimal? GrossAnnualSalary { get; set; } = null;
}

public class SalaryInputModelValidator : AbstractValidator<SalaryInputModel>
{
    public SalaryInputModelValidator()
    {
        RuleFor(x => x.GrossAnnualSalary)
            .NotNull().WithMessage("Please enter a Gross Annual Salary")
            .GreaterThan(0)
            .WithMessage("Gross annual salary must be greater than zero");
    }
}
