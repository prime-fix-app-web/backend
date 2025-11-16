namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

/// <summary>
///     Expected visit aggregate root entity
/// </summary>
public partial class ExpectedVisit
{
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
    public ExpectedVisit(string stateVisit, string visitId, bool isScheduled)
    {
        StateVisit = stateVisit;
        VisitId = visitId;
        IsScheduled = isScheduled;
    }
    public string Id { get; }
    public string StateVisit { get; private set; }
    public string VisitId { get; private set; }
    public bool IsScheduled { get; private set; }
}