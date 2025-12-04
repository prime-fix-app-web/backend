using System.Text.Json.Serialization;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

public record UpdateExpectedVisitRequest(
    
    
    [property:JsonPropertyName("StateOfVisit")]
    Status StateVisit,
    
    [property:JsonPropertyName("visitId")]
    int VisitId,
    
    [property:JsonPropertyName("isSchedule")]
    bool IsScheduled
    
    );