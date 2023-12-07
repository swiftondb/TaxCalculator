using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MockQueryable.Moq;
using Moq;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Application.Tests;

public abstract class TestsBase
{
    private IServiceProvider? _serviceProvider = null;

    protected IServiceProvider ServiceProvider
    {
        get
        {
            if (_serviceProvider == null)
            {
                // Build services
                var services = new ServiceCollection();

                services.AddApplicationServices();

                var mockData = TestData.BuildMock();
                var persistanceMock = new Mock<IPersistence>();
                persistanceMock.Setup(x => x.Query<TaxBand>()).Returns(mockData);
                services.AddSingleton(persistanceMock.Object);

                services.AddLogging();

                _serviceProvider = services.BuildServiceProvider();
            }

            return _serviceProvider;
        }
    }

    private ISender? _sender = null;

    protected ISender Sender
    {
        get
        {
            if (_sender == null)
            {
                _sender = ServiceProvider.GetRequiredService<ISender>();
            }

            return _sender;
        }
    }

    private List<TaxBand> TestData => new List<TaxBand>
    {
        new TaxBand
        {
            TaxBandName = "Tax Band A",
            LowerLimit = 0,
            UpperLimit = 5_000,
            TaxRate = 0,
        },
        new TaxBand
        {
            TaxBandName = "Tax Band B",
            LowerLimit = 5_000,
            UpperLimit = 20_000,
            TaxRate = 20,
        },
        new TaxBand
        {
            TaxBandName = "Tax Band C",
            LowerLimit = 20_000,
            UpperLimit = null, // No upper limit
            TaxRate = 40,
        },
    };
}
