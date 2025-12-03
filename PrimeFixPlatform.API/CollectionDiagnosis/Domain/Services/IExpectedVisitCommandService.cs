using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
///     Represents the contract for expected visit command operations
/// </summary>
public interface IExpectedVisitCommandService
{
    /// <summary>
    ///     Handle the creation of a new expected visit
    /// </summary>
    Task<ExpectedVisit?> Handle(CreateExpectedVisitCommand command);
    
    /// <summary>
    ///     Handle the update od an existing expected
    /// </summary>
    Task<ExpectedVisit?> Handle(UpdateExpectedVisitCommand command);
    
    /// <summary>
    ///     Handles the deletion of a expected visit
    /// </summary>
    Task<ExpectedVisit?> Handle(DeleteExpectedVisitCommand command);
    
    /// <summary>
    /// Handle the cancellation of the visit
    /// </summary>
    Task Handle(CancelVisitCommand command);
    
    /// <summary>
    /// Handle the update of an existing expected visit
    /// </summary>
    Task<ExpectedVisit?> Handle(UpdateStatusExpectedVisitCommand command);
}