using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
/// Resource that represents a service exposed through the REST API.
/// </summary>
/// <param name="Id">
/// Identifier of the service.
/// </param>
/// <param name="Name">
/// Name of the service.
/// </param>
/// <param name="Description">
/// Description of the service.
/// </param>
public record ServiceResponse(
    [property: JsonPropertyName("service_id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string Description
    );