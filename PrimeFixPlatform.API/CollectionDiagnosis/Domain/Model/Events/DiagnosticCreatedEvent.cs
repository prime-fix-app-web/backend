using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

public class DiagnosticCreatedEvent(string diagnosis, VehicleId vehicleId):IEvent
{
    public string Diagnosis { get; private set; }
    public VehicleId VehicleId { get; private set; }
}