namespace PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;
/// <summary>
///     Represents the type of card used in a payment
/// </summary>
/// <param name="Type">
///     The type of the card (e.g., Visa, MasterCard, etc.)
/// </param>
public record CardType(string Type);