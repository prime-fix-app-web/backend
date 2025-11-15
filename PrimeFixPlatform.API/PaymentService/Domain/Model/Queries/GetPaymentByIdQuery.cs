namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
/// <summary>
///     Query to get a payment by its identifier.
/// </summary>
/// <param name="IdPayment">
///     The unique identifier of the payment to be retrieved.
/// </param>
public record GetPaymentByIdQuery(string IdPayment);