using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Request to update a user account
/// </summary>
/// <param name="Username">
///     The username of the user account to be updated
/// </param>
/// <param name="Email">
///     The email of the user account to be updated
/// </param>
/// <param name="RoleId">
///     The role identifier associated with the user account to be updated
/// </param>
/// <param name="UserId">
///     The unique identifier of the user account to be updated
/// </param>
/// <param name="MembershipId">
///     The membership identifier associated with the user account to be updated
/// </param>
/// <param name="Password">
///     The new password for the user account to be updated
/// </param>
/// <param name="IsNew">
///     Flag indicating whether the password is new
/// </param>
public record UpdateUserAccountRequest(
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
    [MinLength(1)]
    int RoleId,
    
    [property: JsonPropertyName("user_id")]
    [Required]
    [MinLength(1)]
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