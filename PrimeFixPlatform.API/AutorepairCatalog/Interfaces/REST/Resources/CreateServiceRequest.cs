using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
/// Request resource used to create a new service inside the auto repair catalog.
/// </summary>
/// <param name="Name">
/// Name of the service to be created.
/// </param>
/// <param name="Description">
/// Description of the service to be created.
/// </param>
public record CreateServiceRequest(
    [property:JsonPropertyName("Name")][Required] string Name,
    [property:JsonPropertyName("Description")][Required] string Description
    );