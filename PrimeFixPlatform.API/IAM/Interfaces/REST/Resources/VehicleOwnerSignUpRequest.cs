using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Represents the data required for a vehicle owner to sign up.
/// </summary>
/// <param name="Name">
///     The first name of the vehicle owner.
/// </param>
/// <param name="LastName">
///     The last name of the vehicle owner.
/// </param>
/// <param name="Dni">
///     The national identification number of the vehicle owner.
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the vehicle owner.
/// </param>
/// <param name="Username">
///     The username chosen by the vehicle owner.
/// </param>
/// <param name="Email">
///     The email address of the vehicle owner.
/// </param>
/// <param name="Password">
///     The password chosen by the vehicle owner.
/// </param>
/// <param name="Address">
///     The address of the vehicle owner.
/// </param>
/// <param name="District">
///     The district where the vehicle owner resides.
/// </param>
/// <param name="Department">
///     The department where the vehicle owner resides.
/// </param>
/// <param name="MembershipDescription">
///     The description of the vehicle owner's membership.
/// </param>
/// <param name="Started">
///     The start date of the vehicle owner's membership.
/// </param>
/// <param name="Over">
///     The end date of the vehicle owner's membership.
/// </param>
/// <param name="CardNumber">
///     The card number associated with the vehicle owner's membership.
/// </param>
/// <param name="CardType">
///     The type of card associated with the vehicle owner's membership.
/// </param>
/// <param name="Month">
///     The expiration month of the card.
/// </param>
/// <param name="Year">
///     The expiration year of the card.
/// </param>
/// <param name="Cvv">
///     The CVV code of the card.
/// </param>
public record VehicleOwnerSignUpRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Name,

    [property: JsonPropertyName("last_name")]
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string LastName,

    [Required]
    [StringLength(8, MinimumLength = 8)]
    string Dni,

    [property: JsonPropertyName("phone_number")]
    [Required]
    [StringLength(15, MinimumLength = 7)]
    string PhoneNumber,
    
    [Required]
    [MinLength(1)]
    [MaxLength(150)]
    string Username,
    
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    string Email,
    
    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    string Password,
    
    [Required]
    [MaxLength(100)]
    string Address,
    
    [Required]
    [MaxLength(50)]
    string District,
    
    [Required]
    [MaxLength(50)]
    string Department,
    
    [property: JsonPropertyName("membership_description")]
    [Required]
    [MaxLength(100)]
    string MembershipDescription, 

    [Required]
    [DataType(DataType.Date)]
    DateOnly Started,
    
    [Required]
    [DataType(DataType.Date)]
    DateOnly Over,
    
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
    int Cvv);