using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Request to create a technician
/// </summary>
/// <param name="IdTechnician">
///     The unique identifier of the technician to be created
/// </param>
/// <param name="Name">
///     The name of the technician to be created
/// </param>
/// <param name="LastName">
///     The last name of the technician to be created
/// </param>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair shop the technician belongs to
/// </param>
public record CreateTechnicianRequest(
    [property: JsonPropertyName("id_technician")]
    [Required]
    [MinLength(1)]
    string IdTechnician,
    
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