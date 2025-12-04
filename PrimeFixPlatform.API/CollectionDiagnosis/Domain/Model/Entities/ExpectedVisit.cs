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
    /// <param name="stateVisit">
    ///     State of the visit
    /// </param>
    /// <param name="visitId">
    ///     The visit ID of the Expected Visit
    /// </param>
    /// <param name="isScheduled">
    ///     The confirmation od the visit
    /// </param>
    public ExpectedVisit(Status stateVisit, int visitId, bool isScheduled)
    {
        StateVisit = stateVisit;
        VisitId = visitId;
        IsScheduled = isScheduled;
    }
    
    /// <summary>
    ///     Constructor for ExpectedVisit entity with data from CreateExpectedVisitCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create ExpectedVisit
    /// </param>
    public ExpectedVisit(CreateExpectedVisitCommand command):this(command.StateVisit, command.VisitId, command.IsScheduled){}

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
    public Status StateVisit { get;  set; }
    public int VisitId { get; private set; }
    public bool IsScheduled { get; set; }
    

    
    public void ChangeStatus(Status status)
    {
        StateVisit = status;
    }
}