using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
///     Request to create an auto repair
/// </summary>
/// <param name="Ruc">
///     The RUC number of the auto repair to be created
/// </param>
/// <param name="ContactEmail">
///     The contact email of the auto repair to be created
/// </param>
/// <param name="TechniciansCount">
///     The number of technicians in the auto repair to be created
/// </param>
/// <param name="UserAccountId">
///     The unique identifier of the user account associated with the auto repair to be created
/// </param>
public record CreateAutoRepairRequest(
    [Required]
    [StringLength(11, MinimumLength = 11)]
    string Ruc,
    
    [property: JsonPropertyName("contact_email")]
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    string ContactEmail,
    
    [property: JsonPropertyName("technicians_count")]
    [Required]
    int TechniciansCount,
    
    [property: JsonPropertyName("user_account_id")]
    [Required]
    int UserAccountId);