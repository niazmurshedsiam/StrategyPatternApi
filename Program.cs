using StrategyPatternApi.Extensions;
using StrategyPatternApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddPaymentStrategies();

var app = builder.Build();

// // Configure middleware
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

// Endpoints
app.MapPost("/process-payment", (PaymentRequest request, PaymentProcessor paymentProcessor,
    CreditCardPaymentStrategy creditCard,
    PayPalPaymentStrategy paypal) =>
{
    // Set strategy based on request
    switch (request.PaymentMethod.ToLower())
    {
        case "creditcard":
            paymentProcessor.SetPaymentStrategy(creditCard);
            break;
        case "paypal":
            paymentProcessor.SetPaymentStrategy(paypal);
            break;

        default:
            return Results.BadRequest("Invalid payment method");
    }

    var result = paymentProcessor.ProcessPayment(request.Amount);

    var response = new PaymentResponse
    {
        Message = result,
        PaymentMethod = paymentProcessor.GetCurrentPaymentMethod(),
        Amount = request.Amount,
        ProcessedAt = DateTime.UtcNow
    };

    return Results.Ok(response);
})
.WithName("ProcessPayment");
//.WithOpenApi();

app.MapGet("/payment-methods", (PaymentProcessor paymentProcessor) =>
{
    var methods = new[]
    {
        new { Name = "creditcard", Description = "Credit Card Payment" },
        new { Name = "paypal", Description = "PayPal Payment" }
    };

    return Results.Ok(methods);
})
.WithName("GetPaymentMethods");
//.WithOpenApi();

app.MapGet("/current-method", (PaymentProcessor paymentProcessor) =>
{
    return Results.Ok(new
    {
        Method = paymentProcessor.GetCurrentPaymentMethod()
    });
})
.WithName("GetCurrentPaymentMethod");

app.Run();
