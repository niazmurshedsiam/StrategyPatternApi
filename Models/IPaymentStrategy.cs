namespace StrategyPatternApi.Models;

public interface IPaymentStrategy
{
    string ProcessPayment(decimal amount);
    string GetPaymentMethod();
}
