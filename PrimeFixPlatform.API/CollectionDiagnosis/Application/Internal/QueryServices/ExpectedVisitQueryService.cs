using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

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

    /// <summary>
    ///     Handles the query to get an expected visit by its identifier
    /// </summary>
    /// <param name="query">
    ///     The query to get an expected visit by its identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the expected visit if found; otherwise, null
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that an expected visit with the specified ID was not found.
    /// </exception>
    public async Task<ExpectedVisit?> Handle(GetExpectedVisitByIdQuery query)
    {
        return await expectedVisitRepository.FindByIdAsync(query.ExpectedVisitId)
            ?? throw new NotFoundIdException("Expected visit with the id " + query.ExpectedVisitId + " was not found.");
    }
}