using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
///     Response model for Location
/// </summary>
/// <param name="IdLocation">
///     The unique identifier of the location
/// </param>
/// <param name="Address">
///     The address of the location
/// </param>
/// <param name="District">
///     The district of the location
/// </param>
/// <param name="Department">
///     The department of the location
/// </param>
public record LocationResponse(
    [property: JsonPropertyName("id_location")] int IdLocation,
    string Address,
    string District,
    string Department);