using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to update a payment's information
/// </summary>
/// <param name="IdPayment">
///     The unique identifier for the payment to be updated
/// </param>
/// <param name="CardNumber">
///     The card number of the payment to be updated
/// </param>
/// <param name="CardType">
///     The card type of the payment to be updated
/// </param>
/// <param name="Month">
///     The month of expiring of the payment to be updated
/// </param>
/// <param name="Year">
///     The year of expiring of the payment to be updated
/// </param>
/// <param name="Cvv">
///     The cvv of the payment to be updated
/// </param>
/// <param name="IdUserAccount">
///     The unique identifier of the user associated with the payment to be updated 
/// </param>
public record UpdatePaymentCommand(string IdPayment, string CardNumber, CardType CardType, int Month,
    int Year, int Cvv, string IdUserAccount);