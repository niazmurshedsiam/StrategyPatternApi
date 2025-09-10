namespace StrategyPatternApi.Models;

public class PaymentResponse
{
    public string Message { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ProcessedAt { get; set; }
}
