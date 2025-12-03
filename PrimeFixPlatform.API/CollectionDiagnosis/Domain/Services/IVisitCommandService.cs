using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

public interface IVisitCommandService
{
    /// <summary>
    ///  Handle the creation of a new visit
    /// </summary>
    Task<Visit?> Handle(CreateVisitCommand command);
    
    /// <summary>
    /// Handles the deletion of a visit
    /// </summary>
    Task<Visit?> Handle(DeleteVisitCommand command);
}