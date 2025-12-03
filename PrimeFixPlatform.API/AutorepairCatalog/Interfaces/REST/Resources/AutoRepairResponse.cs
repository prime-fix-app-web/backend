using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
///     Response representing an auto repair.
/// </summary>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair.
/// </param>
/// <param name="Ruc">
///     The RUC number of the auto repair.
/// </param>
/// <param name="ContactEmail">
///     The contact email of the auto repair.
/// </param>
/// <param name="TechniciansCount">
///     The number of technicians in the auto repair.
/// </param>
/// <param name="IdUserAccount">
///     The unique identifier of the user account associated with the auto repair.
/// </param>
public record AutoRepairResponse(
    [property: JsonPropertyName("id_auto_repair")] int IdAutoRepair,
    string Ruc,
    [property: JsonPropertyName("contact_email")] string ContactEmail,
    [property: JsonPropertyName("technicians_count")] int TechniciansCount,
    [property: JsonPropertyName("id_user_account")] int IdUserAccount);