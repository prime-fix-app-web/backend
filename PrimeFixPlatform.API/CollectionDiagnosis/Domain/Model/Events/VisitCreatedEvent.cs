using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

public class VisitCreatedEvent(string failure, AutoRepairId autoRepairId,VehicleId vehicleId):IEvent
{
    public string Failure { get; private set; }
    public AutoRepairId AutoRepairId { get; private set; }
    public VehicleId VehicleId { get; private set; }
}