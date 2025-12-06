using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Request to create a technician
/// </summary>
/// <param name="Name">
///     The name of the technician to be created
/// </param>
/// <param name="LastName">
///     The last name of the technician to be created
/// </param>
/// <param name="AutoRepairId">
///     The unique identifier of the auto repair shop the technician belongs to
/// </param>
public record CreateTechnicianRequest(
    
    [Required]
    [MaxLength(100)]
    string Name,
    
    [property: JsonPropertyName("last_name")]
    [Required]
    [MaxLength(100)]
    string LastName,
    
    [property: JsonPropertyName("auto_repair_id")]
    [Required]
    int AutoRepairId);