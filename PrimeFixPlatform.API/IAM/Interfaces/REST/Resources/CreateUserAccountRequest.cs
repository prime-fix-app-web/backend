using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Request to create a user account
/// </summary>
/// <param name="IdUserAccount">
///     The unique identifier for the user account to be created
/// </param>
/// <param name="Username">
///     The username of the user account to be created
/// </param>
/// <param name="Email">
///     The email of the user account to be created
/// </param>
/// <param name="IdRole">
///     The role identifier associated with the user account to be created
/// </param>
/// <param name="IdUser">
///     The user identifier associated with the user account to be created
/// </param>
/// <param name="Password">
///     The password of the user account to be created
/// </param>
/// <param name="IsNew">
///     Flag indicating if the user account is new
/// </param>
public record CreateUserAccountRequest(
    [property: JsonPropertyName("id_user_account")]
    [Required]
    [MinLength(1)]
    string IdUserAccount,
    
    [Required]
    [MinLength(1)]
    [MaxLength(150)]
    string Username,
    
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    string Email,
    
    [property: JsonPropertyName("id_role")]
    [Required]
    [MinLength(1)]
    string IdRole,
    
    [property: JsonPropertyName("id_user")]
    [Required]
    [MinLength(1)]
    string IdUser,
    
    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    string Password,
    
    [property: JsonPropertyName("is_new")]
    [Required]
    bool IsNew);