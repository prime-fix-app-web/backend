using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.CommandServices;

/// <summary>
///     Command service for Expected Visit aggregate
/// </summary>
/// <param name="expectedVisitRepository">
///     The expected visit repository
/// </param>
/// <param name="unitOfWork">
///     Unit of Work
/// </param>
public class ExpectedVisitCommandService(IExpectedVisitRepository expectedVisitRepository, IUnitOfWork unitOfWork): IExpectedVisitCommandService
{
    /// <summary>
    ///     Handles the command to create a new Expected Visit
    /// </summary>
    /// <param name="command">
    ///     The command to create a new expected visit
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation, The task result contains the created expected visit
    /// </returns>
    public async Task<ExpectedVisit?> Handle(CreateExpectedVisitCommand command)
    {
        var expected = new ExpectedVisit(command);
        await expectedVisitRepository.AddAsync(expected);
        await unitOfWork.CompleteAsync();
        return expected;
    }
    
    /// <summary>
    ///     Handle the command to update an exiting expected visit
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing expected visit
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operations. The task result contains the update expected visit
    /// </returns>
    /// <exception cref="NotImplementedException">
    ///     Indicates that the expected visit with the specified expectedVisitID was not found
    /// </exception>
    public async Task<ExpectedVisit?> Handle(UpdateExpectedVisitCommand command)
    {
        var expectedVisitId = command.Id;
        var expectedToUpdate = await expectedVisitRepository.FindById(expectedVisitId);

        if (expectedToUpdate == null)
        {
            throw new NotFoundArgumentException("Expected visit not found");
        }
        
        expectedToUpdate.UpdateExpectedVisit(command);
        
        expectedVisitRepository.Update(expectedToUpdate);
        await unitOfWork.CompleteAsync();
        
        return expectedToUpdate;
    }
    
    /// <summary>
    ///     Handles the command to delete a expected visit
    /// </summary>
    /// <param name="command">
    ///     The command to delete a expected visit
    /// </param>
    /// <returns>
    ///     A task represents the asynchronous operation. The task result contains the deleted expected visit
    /// </returns>
    /// <exception cref="NotImplementedException">
    ///     Indicates that the expected with the specified expectedVisitID was not found
    /// </exception>
    public async Task<ExpectedVisit?> Handle(DeleteExpectedVisitCommand command)
    {
        var expected = await expectedVisitRepository.FindById(command.ExpectedVisitId);
        if (expected == null)
        {
            throw new NotFoundArgumentException("Expected was not found");
        }
        expectedVisitRepository.Remove(expected);
        await unitOfWork.CompleteAsync();
        return expected;
    }
    
    /// <summary>
    ///     Cancels a visit associated with the given visit ID.
    /// </summary>
    /// <param name="command">
    ///     Command containing the visit ID to cancel.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Thrown when no expected visit is found for the specified visit ID.
    /// </exception>
    public async Task Handle(CancelVisitCommand command)
    {
        var expectedVisit = await expectedVisitRepository.FindByVisitId(command.VisitId);
        if (expectedVisit == null)
            throw new NotFoundArgumentException("Expected Visit not found");
        expectedVisit.StateVisit = Status.CANCELADO;
        expectedVisit.IsScheduled = false;

        await unitOfWork.CompleteAsync();
    }

    /// <summary>
    ///     Updates the status of an expected visit.
    /// </summary>
    /// <param name="command">
    ///     Command containing the expected visit ID and the new status value.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation.
    ///     The task result contains the updated <see cref="ExpectedVisit"/>.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Thrown when the expected visit with the specified ID is not found.
    /// </exception>
    public async Task<ExpectedVisit?> Handle(UpdateStatusExpectedVisitCommand command)
    {
        var expectedVisit = await expectedVisitRepository.FindById(command.ExpectedVisitId);
        if (expectedVisit == null)
            throw new NotFoundArgumentException("Expected Visit not found");

        expectedVisit.StateVisit = command.NewStatus;
        expectedVisit.IsScheduled = true;

        await unitOfWork.CompleteAsync();
        return expectedVisit;
        
    }
}