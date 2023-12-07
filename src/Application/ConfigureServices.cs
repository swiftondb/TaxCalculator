﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaxCalculator.Application;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
