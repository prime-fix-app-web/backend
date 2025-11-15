using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
///     Represents the contract for a visit query services
/// </summary>
public interface IVisitQueryService
{
    /// <summary>
    ///     Hanldes the retrieval of all visit
    /// </summary>
    Task<IEnumerable<Visit>> Handle(GetAllVisitsQuery query);

    /// <summary>
    ///     Handles tre retrieval of a visit by its unique identifier
    /// </summary>
    Task<Visit?> Handle(GetAllVisitByAutoRepairIdQuery query);
}