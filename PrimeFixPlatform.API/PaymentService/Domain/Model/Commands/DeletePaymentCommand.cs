namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to delete a payment
/// </summary>
/// <param name="IdPayment"></param>
public record DeletePaymentCommand(string IdPayment);