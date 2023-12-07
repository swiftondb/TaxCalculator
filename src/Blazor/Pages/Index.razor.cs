using MediatR;
using Microsoft.AspNetCore.Components;
using TaxCalculator.Application.Features.TaxBands.Dtos;
using TaxCalculator.Application.Features.TaxBands.Queries;
using TaxCalculator.Blazor.Models;

namespace TaxCalculator.Blazor.Pages;

public partial class Index
{
    [Inject]
    public ISender Sender { get; set; } = null!;

    [Inject]
    public ILogger<Index> Logger { get; set; } = null!;

    private SalaryInputModel SalaryInput { get; } = new SalaryInputModel();

    private CalculateTaxResultDto? Result { get; set; } = null;

    private bool isWorking = false;
    private string? errorMessage = null;

    private async Task HandleValidSubmit()
    {
        if (!SalaryInput.GrossAnnualSalary.HasValue)
        {
            return;
        }

        try
        {
            isWorking = true;
            StateHasChanged();

            Result = await Sender.Send(new CalculateTaxQuery(SalaryInput.GrossAnnualSalary.Value));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to calculate tax");
            errorMessage = "Error whilst calculating tax";
        }
        finally
        {
            isWorking = false;
        }
    }

    private void HandleInvalidSubmit()
    {
        // Hide results
        Result = null;
    }
}
