using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record ExpectedVisitResponse(
    [property:JsonPropertyName("id")]
    int Id,
    
    [property:JsonPropertyName("StateOfVisit")]
    string StateVisit,
    
    [property:JsonPropertyName("visitId")]
    int VisitId,
    
    [property:JsonPropertyName("isSchedule")]
    bool IsScheduled
    
    
    );