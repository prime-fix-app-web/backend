using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Request to create a role
/// </summary>
/// <param name="IdRole">
///     The unique identifier of the role to be created
/// </param>
/// <param name="Name">
///     The name of the role to be created
/// </param>
/// <param name="Description">
///     The description of the role to be created
/// </param>
public record CreateRoleRequest(
    [property: JsonPropertyName("id_role")]
    [Required]
    [MinLength(1)]
    string IdRole,
    
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Name,
    
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    string Description);