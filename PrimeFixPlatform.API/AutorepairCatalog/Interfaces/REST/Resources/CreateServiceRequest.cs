using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record CreateServiceRequest(
    [property:JsonPropertyName("Name")][Required] string Name,
    [property:JsonPropertyName("Description")][Required] string Description
    );