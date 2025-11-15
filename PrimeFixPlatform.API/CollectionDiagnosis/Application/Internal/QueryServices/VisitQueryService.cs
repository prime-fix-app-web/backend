using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.QueryServices;

/// <summary>
///     Query service for visit aggregate
/// </summary>
/// <param name="visitRepository"></param>
public class VisitQueryService(IVisitRepository visitRepository): IVisitQueryService
{
    /// <summary>
    /// Handles the query to get all Visits
    /// </summary>
    /// <param name="query">
    ///     The query to get all visits
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an enumerable of visits
    /// </returns>
    public async Task<IEnumerable<Visit>> Handle(GetAllVisitsQuery query)
    {
        return await visitRepository.ListAsync();
    }
    
    /// <summary>
    ///     Handles the query to get a visits by the AutoRepairID
    /// </summary>
    /// <param name="query">
    ///     The query to get visits by the AutoRepairID
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operations. The task result contains the diagnostic if found; otherwise, null.  
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that a visit with the specified identifier was no found
    /// </exception>
    public async Task<Visit?> Handle(GetAllVisitByAutoRepairIdQuery query)
    {
        return await visitRepository.FindByAutoRepairId(query.AutoRepairId) ??
               throw new NotFoundArgumentException("Visit with the Auto Repair ID" + query.AutoRepairId
                   + "was not found");
    }
}