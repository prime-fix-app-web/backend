using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;

/// <summary>
/// Visit aggregate root entity
/// </summary>
public partial class Visit
{
    /// <summary>
    /// Private constructor for Visit aggregate root entity
    /// </summary>
    /// <param name="failure">
    ///     The description of the vehicle fault
    /// </param>
    /// <param name="vehicleId">
    ///     The ID of the vehicle designated for the visit 
    /// </param>
    /// <param name="timeVisit">
    ///     The date assigned for the visit
    /// </param>
    /// <param name="autoRepairId">
    ///     The ID of the auto repair designated for the visit
    /// </param>
    /// <param name="serviceId">
    ///     The ID of the service designated for the visit
    /// </param>
    public Visit(string failure, string vehicleId, string timeVisit, string autoRepairId, string serviceId)
    {
        Failure = failure;
        VehicleId = vehicleId;
        TimeVisit = timeVisit;
        AutoRepairId = autoRepairId;
        ServiceId = serviceId;
    }

    /// <summary>
    ///  Constructor for visit aggregate root entity from CreateVisitCommand
    /// </summary>
    /// <param name="command">
    ///     Command objects containing data to create a visit.
    /// </param>
    public Visit(CreateVisitCommand command):this(command.failure, command.vehicleId, command.timeVisit,
        command.autoRepairId, command.serviceId){}
    
    
    public string Id { get; }
    public string Failure { get; private set; }
    
    public string VehicleId { get; private set; }
    
    public string TimeVisit { get; private set; }
    
    public string AutoRepairId { get; private set; }
    
    public string ServiceId { get; private set; }
    
    public Service Service { get; internal set; }
}