using System;
using StrategyPatternApi.Models;

namespace StrategyPatternApi.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddPaymentStrategies(this IServiceCollection services)
    {
        services.AddTransient<CreditCardPaymentStrategy>();
        services.AddTransient<PayPalPaymentStrategy>();
        
        services.AddSingleton<PaymentProcessor>();
        
        return services;
    }
}


