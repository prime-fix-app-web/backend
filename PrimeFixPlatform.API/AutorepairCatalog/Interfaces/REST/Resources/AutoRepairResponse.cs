using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
///     Response representing an auto repair.
/// </summary>
/// <param name="Id">
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
/// <param name="UserAccountId">
///     The unique identifier of the user account associated with the auto repair.
/// </param>
public record AutoRepairResponse(
    int Id,
    string Ruc,
    [property: JsonPropertyName("contact_email")] string ContactEmail,
    [property: JsonPropertyName("technicians_count")] int TechniciansCount,
    [property: JsonPropertyName("user_account_id")] int UserAccountId,
    [property: JsonPropertyName("service_catalog")] IReadOnlyList<ServiceOfferResource> ServiceCatalog
    
    );