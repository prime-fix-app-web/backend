using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record UpdateExpectedVisitRequest(
    
    
    [property:JsonPropertyName("state_visit")]
    Status StateVisit,
    
    [property:JsonPropertyName("visit_id")]
    int VisitId,
    
    [property:JsonPropertyName("is_scheduled")]
    bool IsScheduled
    
    );