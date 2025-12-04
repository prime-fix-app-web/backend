using System.Text.Json.Serialization;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

/// <summary>
///     Response representing a payment
/// </summary>
/// <param name="IdPayment">
///     The unique identifier of the payment
/// </param>
/// <param name="CardNumber">
///     The card number of the payment
/// </param>
/// <param name="CardType">
///     The card type of the payment
/// </param>
/// <param name="Month">
///     The month of expiring of the payment
/// </param>
/// <param name="Year">
///     The year of expiring of the payment
/// </param>
/// <param name="Cvv">
///     The cvv  of the payment
/// </param>
/// <param name="IdUserAccount">
///     The identifier of the user account of the payment
/// </param>
public record PaymentResponse(
    [property:JsonPropertyName("id_payment")] int IdPayment,
    [property:JsonPropertyName("card_number")] string CardNumber,
    [property:JsonPropertyName("card_type")] string CardType,
    int Month,
    int Year,
    int Cvv,
    [property:JsonPropertyName("id_user_account")] int IdUserAccount
    );