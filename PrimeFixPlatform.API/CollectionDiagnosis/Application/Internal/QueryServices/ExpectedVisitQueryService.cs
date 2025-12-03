using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.QueryServices;

public class ExpectedVisitQueryService(IExpectedVisitRepository expectedVisitRepository):IExpectedVisitQueryService
{
    /// <summary>
    ///     Handles the query to get all expected visit
    /// </summary>
    /// <param name="query">
    ///     The query to get all expected visit
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a enumerable of expected visit
    /// </returns>
    public async Task<IEnumerable<ExpectedVisit>> Handle(GetAllExpectedVisitsQuery query)
    {
        return await expectedVisitRepository.ListAsync();
    }
}