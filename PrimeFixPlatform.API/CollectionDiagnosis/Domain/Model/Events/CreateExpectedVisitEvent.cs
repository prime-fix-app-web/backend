using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

public class CreateExpectedVisitEvent(int visitId):IEvent
{
    public Status Status;
    public int VisitId { get; set; }= visitId;
    public bool IsScheduled { get; set; }
    
}