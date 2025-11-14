using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

public record UpdateUserAccountRequest(
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