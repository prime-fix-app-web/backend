using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Represents a request to update an existing role.
/// </summary>
/// <param name="Name">
///     The name of the role to be updated.
/// </param>
/// <param name="Description">
///     The description of the role to be updated.
/// </param>
public record UpdateRoleRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Name,
    
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    string Description);