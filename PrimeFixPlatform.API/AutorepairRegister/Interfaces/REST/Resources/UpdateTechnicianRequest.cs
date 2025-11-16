using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Request to update a technician
/// </summary>
/// <param name="Name">
///     The name of the technician to updated
/// </param>
/// <param name="LastName">
///     The last name of the technician to updated
/// </param>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair shop the technician belongs to
/// </param>
public record UpdateTechnicianRequest(
    [Required]
    [MaxLength(100)]
    string Name,
    
    [Required]
    [MaxLength(100)]
    string LastName,
    
    [property: JsonPropertyName("id_auto_repair")]
    [Required]
    [MinLength(1)]
    string IdAutoRepair);