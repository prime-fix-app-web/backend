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
    
}