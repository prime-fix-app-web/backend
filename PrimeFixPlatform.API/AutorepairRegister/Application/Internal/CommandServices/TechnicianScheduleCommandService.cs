using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairRegister.Application.Internal.CommandServices;

/// <summary>
///     Command service for Technician Schedule aggregate
/// </summary>
/// <param name="technicianScheduleRepository">
///     The technician schedule repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class TechnicianScheduleCommandService(ITechnicianScheduleRepository technicianScheduleRepository, IUnitOfWork unitOfWork)
: ITechnicianScheduleCommandService
{
    /// <summary>
    ///     Handles the command to create a new technician schedule
    /// </summary>
    /// <param name="command">
    ///     The command to create a new technician schedule
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created technician schedule's ID.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a technician schedule with the same id already exists
    /// </exception>
    public async Task<int> Handle(CreateTechnicianScheduleCommand command)
    {
        var technicianSchedule = new TechnicianSchedule(command);
        await technicianScheduleRepository.AddAsync(technicianSchedule);
        await unitOfWork.CompleteAsync();
        return technicianSchedule.Id;
    }

    /// <summary>
    ///     Handles the command to update an existing technician schedule
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing technician schedule
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated technician schedule.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a technician schedule with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the technician schedule to update was not found
    /// </exception>
    public async Task<TechnicianSchedule?> Handle(UpdateTechnicianScheduleCommand command)
    {
        var technicianScheduleId = command.TechnicianScheduleId;
        
        if (!await technicianScheduleRepository.ExistsByTechnicianScheduleId(technicianScheduleId))
            throw new NotFoundIdException("Technician Schedule with id " + technicianScheduleId  + " does not exist");
        
        var technicianScheduleToUpdate = await technicianScheduleRepository.FindByIdAsync(technicianScheduleId);
        if (technicianScheduleToUpdate is null)
            throw new NotFoundArgumentException("Technician Schedule not found");
        technicianScheduleToUpdate.UpdateTechnicianSchedule(command);
        technicianScheduleRepository.Update(technicianScheduleToUpdate);
        await unitOfWork.CompleteAsync();
        return technicianScheduleToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing technician schedule
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing technician schedule
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a technician schedule with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the technician schedule to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteTechnicianScheduleCommand command)
    {
        if (!await technicianScheduleRepository.ExistsByTechnicianScheduleId(command.TechnicianScheduleId))
            throw new NotFoundIdException("Technician Schedule with id " + command.TechnicianScheduleId  + " does not exist");
        var technicianSchedule = await technicianScheduleRepository.FindByIdAsync(command.TechnicianScheduleId);
        if (technicianSchedule is null)
            throw new NotFoundArgumentException("Technician Schedule not found");
        technicianScheduleRepository.Remove(technicianSchedule);
        await unitOfWork.CompleteAsync();
        return true;
    }
}