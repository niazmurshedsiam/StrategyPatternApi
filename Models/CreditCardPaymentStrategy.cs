namespace StrategyPatternApi.Models;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
     public string ProcessPayment(decimal amount)
    {
        return $"Processing credit card payment of ${amount}";
    }

    public string GetPaymentMethod()
    {
        return "Credit Card";
    }
}
