namespace StrategyPatternApi.Models;

public class PayPalPaymentStrategy: IPaymentStrategy
{
    public string ProcessPayment(decimal amount)
    {
        return $"Processing PayPal payment of ${amount}";
    }

    public string GetPaymentMethod()
    {
        return "PayPal";
    }
}
