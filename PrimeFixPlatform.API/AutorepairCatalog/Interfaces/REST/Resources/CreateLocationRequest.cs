using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
///     Request to create a new location
/// </summary>
/// <param name="IdLocation">
///     The unique identifier for the location to be created
/// </param>
/// <param name="Address">
///     The address of the location to be created
/// </param>
/// <param name="District">
///     The district where the location is situated
/// </param>
/// <param name="Department">
///     The department where the location is situated
/// </param>
public record CreateLocationRequest(
    [property: JsonPropertyName("id_location")]
    [Required]
    int IdLocation,
    
    [Required]
    [MaxLength(100)]
    string Address,
    
    [Required]
    [MaxLength(50)]
    string District,
    
    [Required]
    [MaxLength(50)]
    string Department);