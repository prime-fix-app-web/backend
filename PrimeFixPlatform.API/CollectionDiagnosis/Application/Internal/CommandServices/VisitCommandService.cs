using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.CommandServices;

/// <summary>
///      Command service for a visit aggregate
/// </summary>
/// <param name="visitRepository">
///     The visit repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class VisitCommandService(IVisitRepository visitRepository, IUnitOfWork unitOfWork): IVisitCommandService
{
    /// <summary>
    ///     Handles the command to create a visit
    /// </summary>
    /// <param name="command">
    ///     The command to create a new visit
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created visit.
    /// </returns>
    public async Task<Visit?> Handle(CreateVisitCommand command)
    {
        var visit = new Visit(command);
        await visitRepository.AddAsync(visit);
        await unitOfWork.CompleteAsync();
        return visit;
    }

    /// <summary>
    ///     Handles the command to delete a visit
    /// </summary>
    /// <param name="command">
    ///     The command to delete a visit
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the deleted visit
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user with the specified visitID was not found
    /// </exception>
    public async Task<Visit?> Handle(DeleteVisitCommand command)
    {
        var visit = await visitRepository.FindByIdAsync(command.VisitId);
        if (visit == null)
            throw new NotFoundArgumentException("Visit not found");
        visitRepository.Remove(visit);
        await unitOfWork.CompleteAsync();
        return visit;
    }
}