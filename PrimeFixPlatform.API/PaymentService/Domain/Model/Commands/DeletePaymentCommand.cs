namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to delete a payment
/// </summary>
/// <param name="PaymentId"></param>
public record DeletePaymentCommand(int PaymentId);