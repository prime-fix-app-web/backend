using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

/// <summary>
///     Expected visit aggregate root entity
/// </summary>
public partial class ExpectedVisit
{
    protected ExpectedVisit(){}
    
    /// <summary>
    ///     Constructor for Expected Visit entity
    /// </summary>
    /// <param name="visitId">
    ///     The visit ID of the Expected Visit
    /// </param>
    /// <param name="vehicleId">
    ///     The vehicle ID associated with the Expected Visit
    /// </param>
    public ExpectedVisit(int visitId, int vehicleId)
    {
        StateVisit = EStateVisit.SCHEDULED_VISIT;
        VisitId = visitId;
        IsScheduled = false;
        VehicleId = vehicleId;
    }
    
    /// <summary>
    ///     Constructor for ExpectedVisit entity with data from CreateExpectedVisitCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create ExpectedVisit
    /// </param>
    public ExpectedVisit(CreateExpectedVisitCommand command):this(command.VisitId, command.VehicleId){}

    /// <summary>
    /// Updates the expected visit entity with data form UpdateExpectedVisitCommand
    /// </summary>
    /// <param name="command"></param>
    public void UpdateExpectedVisit(UpdateExpectedVisitCommand command)
    {
        StateVisit = command.StateVisit;
        VisitId = command.VisitId;
        IsScheduled = command.IsScheduled;
    }
    
    
    public int Id { get; }
    public EStateVisit StateVisit { get;  set; }
    public int VisitId { get; internal set; }
    public bool IsScheduled { get; set; }
    
    public int VehicleId { get; private set; }
    
    
    /// <summary>
    ///     Changes the status of the expected visit
    /// </summary>
    /// <param name="stateVisit">
    ///     The new state visit to be set
    /// </param>
    public void ChangeStatus(EStateVisit stateVisit)
    {
        StateVisit = stateVisit;
    }
}