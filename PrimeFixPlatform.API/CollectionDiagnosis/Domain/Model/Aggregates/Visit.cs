using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;

/// <summary>
/// Visit aggregate root entity
/// </summary>
public partial class Visit
{
    public Visit(string failure, string vehicleId, string timeVisit, string autoRepairId, string serviceId)
    {
        Failure = failure;
        VehicleId = vehicleId;
        TimeVisit = timeVisit;
        AutoRepairId = autoRepairId;
        ServiceId = serviceId;
    }
    
    
    public string Failure { get; private set; }
    
    public string VehicleId { get; private set; }
    
    public string TimeVisit { get; private set; }
    
    public string AutoRepairId { get; private set; }
    
    public string ServiceId { get; private set; }
    
    public Service Service { get; internal set; }
}