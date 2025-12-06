using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
///     Represents the contract for a expected visit query services
/// </summary>
public interface IExpectedVisitQueryService
{
    /// <summary>
    ///     Handle the retrieval of all expected visit
    /// </summary>
    /// <param name="query">
    ///     The query object containing paraments for retrieving all expected visit
    /// </param>
    Task<IEnumerable<ExpectedVisit>> Handle(GetAllExpectedVisitsQuery query);
    
    /// <summary>
    ///     Handle the retrieval of an expected visit by its identifier
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving an expected visit by its identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the expected visit if found; otherwise, null
    /// </returns>
    Task<ExpectedVisit?> Handle(GetExpectedVisitByIdQuery query);
}