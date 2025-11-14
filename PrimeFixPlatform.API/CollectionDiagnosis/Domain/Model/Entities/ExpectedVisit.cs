namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

/// <summary>
///     Expected visit aggregate root entity
/// </summary>
public partial class ExpectedVisit
{
    public ExpectedVisit(string stateVisit, string visitId, bool isScheduled)
    {
        StateVisit = stateVisit;
        VisitId = visitId;
        IsScheduled = isScheduled;
    }
    
    public string StateVisit { get; private set; }
    public string VisitId { get; private set; }
    public bool IsScheduled { get; private set; }
}