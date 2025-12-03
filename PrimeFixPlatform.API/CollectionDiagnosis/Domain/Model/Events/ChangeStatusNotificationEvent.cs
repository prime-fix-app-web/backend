using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

public class ChangeStatusNotificationEvent(Status status, string message, int vehicleId, DateTime sent): IEvent
{
    public enum Status;
    public string Message { get; set; }
    public int VehicleId { get; set; }
    public DateTime Sent { get; set; }
    
}