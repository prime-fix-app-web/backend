using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;

/// <summary>
///     Response for a technician
/// </summary>
/// <param name="Id">
///     The unique identifier of the technician
/// </param>
/// <param name="Name">
///     The name of the technician
/// </param>
/// <param name="LastName">
///     The last name of the technician
/// </param>
/// <param name="AutoRepairId">
///     The unique identifier of the auto repair shop the technician belongs to
/// </param>
public record TechnicianResponse(
    int Id,
    string Name,
    string LastName,
    [property: JsonPropertyName("auto_repair_id")] int AutoRepairId);