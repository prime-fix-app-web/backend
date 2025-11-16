using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Response for a technician
/// </summary>
/// <param name="IdTechnician">
///     The unique identifier of the technician
/// </param>
/// <param name="Name">
///     The name of the technician
/// </param>
/// <param name="LastName">
///     The last name of the technician
/// </param>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair shop the technician belongs to
/// </param>
public record TechnicianResponse(
    [property: JsonPropertyName("id_technician")] string IdTechnician,
    string Name,
    string LastName,
    [property: JsonPropertyName("id_auto_repair")] string IdAutoRepair);