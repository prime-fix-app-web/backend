using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;

/// <summary>
/// Visit aggregate root entity
/// </summary>
public partial class Visit
{
    protected Visit(){}
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
    public Visit(string failure, int vehicleId, string timeVisit, int autoRepairId, int serviceId)
    {
        Failure = failure;
        VehicleId = new VehicleId(vehicleId);
        TimeVisit = timeVisit;
        AutoRepairId = new AutoRepairId(autoRepairId);
        ServiceId = new ServiceId(serviceId);
    }

    /// <summary>
    ///  Constructor for visit aggregate root entity from CreateVisitCommand
    /// </summary>
    /// <param name="command">
    ///     Command objects containing data to create a visit.
    /// </param>
    public Visit(CreateVisitCommand command):this(command.Failure, command.VehicleId, command.TimeVisit,
        command.AutoRepairId, command.ServiceId){}
    
    
    public int Id { get; }
    public string Failure { get; private set; }
    
    public VehicleId VehicleId { get; private set; }
    
    public string TimeVisit { get; private set; }
    
    public AutoRepairId AutoRepairId { get; private set; }
    
    public ServiceId ServiceId { get; private set; }
    
    
}