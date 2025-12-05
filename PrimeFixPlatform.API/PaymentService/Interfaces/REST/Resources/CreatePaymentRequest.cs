using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

/// <summary>
///     Request to create a payment
/// </summary>
/// <param name="IdPayment">
///     The unique identifier of the payment to be created
/// </param>
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
///     The cvv  of the payment to be created
/// </param>
/// <param name="UserAccountId">
///     The identifier of the user account of the payment to be created
/// </param>
public record CreatePaymentRequest(

    
    [property: JsonPropertyName("card_number")]
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string CardNumber,
    
    [property: JsonPropertyName("card_type")]
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string CardType,
    
    [Required]
    int Month,
    
    [Required]
    int Year,
    
    [Required]
    int Cvv,
    
    [property: JsonPropertyName("user_account_id")]
    [Required]
    int UserAccountId);