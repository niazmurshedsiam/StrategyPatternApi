namespace StrategyPatternApi.Models;

public class PaymentProcessor
{
private IPaymentStrategy _paymentStrategy;

    public PaymentProcessor()
    {
        // Default strategy
        _paymentStrategy = new CreditCardPaymentStrategy();
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public string ProcessPayment(decimal amount)
    {
        return _paymentStrategy.ProcessPayment(amount);
    }

    public string GetCurrentPaymentMethod()
    {
        return _paymentStrategy.GetPaymentMethod();
    }
}
