using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

/// <summary>
///     Command to create a new payment
/// </summary>
/// <param name="CardNumber">
///     The card number of the payment to be created
/// </param>
/// <param name="CardType">
///     The card type of the payment to be created
/// </param>
/// <param name="Month">
///     The month of expiring of the payment to be created
/// </param>
/// <param name="Year">
///     The year of expiring of the payment to be created
/// </param>
/// <param name="Cvv">
///     The cvv of the payment to be created
/// </param>
/// <param name="UserAccountId">
///     The unique identifier of the user associated with the payment to be created 
/// </param>
public record CreatePaymentCommand( string CardNumber, CardType CardType, int Month,
    int Year, int Cvv, int UserAccountId);