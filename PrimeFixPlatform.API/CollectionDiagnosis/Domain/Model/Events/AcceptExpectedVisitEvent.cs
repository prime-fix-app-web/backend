using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

public class AcceptExpectedVisitEvent(string message, int vehicleId, DateTime sent) : IEvent
{
    public string Message { get; }
    public int VehicleId { get; }
    public DateTime Sent { get; }
    
}