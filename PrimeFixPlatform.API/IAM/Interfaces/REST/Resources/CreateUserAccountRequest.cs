using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Request to create a user account
/// </summary>
/// <param name="Username">
///     The username of the user account to be created
/// </param>
/// <param name="Email">
///     The email of the user account to be created
/// </param>
/// <param name="RoleId">
///     The role identifier associated with the user account to be created
/// </param>
/// <param name="UserId">
///     The user identifier associated with the user account to be created
/// </param>
/// <param name="MembershipId">
///     The membership identifier associated with the user account to be created
/// </param>
/// <param name="Password">
///     The password of the user account to be created
/// </param>
/// <param name="IsNew">
///     Flag indicating if the user account is new
/// </param>
public record CreateUserAccountRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(150)]
    string Username,
    
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    string Email,
    
    [property: JsonPropertyName("role_id")]
    [Required]
    int RoleId,
    
    [property: JsonPropertyName("user_id")]
    [Required]
    int UserId,
    
    [property: JsonPropertyName("membership_id")]
    [Required]
    int MembershipId,
    
    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    string Password,
    
    [property: JsonPropertyName("is_new")]
    [Required]
    bool IsNew);