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
/// <param name="expectedVisitCommandService">
///     The expected visit command service
/// </param>
/// <param name="expectedVisitRepository">
///     The expected visit repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class VisitCommandService(IVisitRepository visitRepository, 
    IExpectedVisitCommandService expectedVisitCommandService,
    IExpectedVisitRepository expectedVisitRepository,
    IUnitOfWork unitOfWork): 
    IVisitCommandService
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
        await using var transaction = await unitOfWork.BeginTransactionAsync();
        try
        {
            // Create visit
            var visit = new Visit(command);
            await visitRepository.AddAsync(visit);
            await unitOfWork.CompleteAsync(); // Save visit to get the generated ID

            // Create expected visit
            var expectedVisitId = await expectedVisitCommandService
                .Handle(new CreateExpectedVisitCommand(visit.Id, command.VehicleId));

            // Verify created expected visit
            var expectedVisit = await expectedVisitRepository.FindById(expectedVisitId);
            if (expectedVisit == null)
                throw new NotFoundArgumentException("Expected visit not found");

            await transaction.CommitAsync();
            return visit;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
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
        var visit = await visitRepository.FindById(command.VisitId);
        if (visit == null)
            throw new NotFoundArgumentException("Visit not found");
        visitRepository.Remove(visit);
        await unitOfWork.CompleteAsync();
        return visit;
    }


}