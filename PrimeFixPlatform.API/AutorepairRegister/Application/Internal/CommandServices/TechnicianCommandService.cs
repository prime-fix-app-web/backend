using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairRegister.Application.Internal.CommandServices;

/// <summary>
///     Command service for Technician aggregate
/// </summary>
/// <param name="technicianRepository">
///     The technician repository
/// </param>
/// <param name="unitOfWork">
///     The unit of work
/// </param>
public class TechnicianCommandService(ITechnicianRepository technicianRepository, IUnitOfWork unitOfWork)
: ITechnicianCommandService
{
    /// <summary>
    ///     Handles the command to create a new technician
    /// </summary>
    /// <param name="command">
    ///     The command to create a new technician
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created technician's ID.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a technician with the same id already exists
    /// </exception>
    public async Task<string> Handle(CreateTechnicianCommand command)
    {
        var idTechnician = command.IdTechnician;
        
        if (await technicianRepository.ExistsByIdTechnician(idTechnician))
            throw new ConflictException("Technician with the same id " + idTechnician  + " already exists");
        
        var technician = new Technician(command);
        await technicianRepository.AddAsync(technician);
        await unitOfWork.CompleteAsync();
        return technician.IdTechnician;
    }

    /// <summary>
    ///     Handles the command to update an existing technician
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing technician
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated technician.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a technician with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the technician to update was not found
    /// </exception>
    public async Task<Technician?> Handle(UpdateTechnicianCommand command)
    {
        var idTechnician = command.IdTechnician;
        
        if (!await technicianRepository.ExistsByIdTechnician(idTechnician))
            throw new NotFoundIdException("Technician with id " + idTechnician  + " does not exist");
        
        var technicianToUpdate = await technicianRepository.FindByIdAsync(idTechnician);
        if (technicianToUpdate == null)
            throw new NotFoundArgumentException("Technician not found");
        technicianToUpdate.UpdateTechnician(command);
        technicianRepository.Update(technicianToUpdate);
        await unitOfWork.CompleteAsync();
        return technicianToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing technician
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing technician
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a technician with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the technician to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteTechnicianCommand command)
    {
        if (!await technicianRepository.ExistsByIdTechnician(command.IdTechnician))
            throw new NotFoundIdException("Technician with id " + command.IdTechnician  + " does not exist");
        var technician = await technicianRepository.FindByIdAsync(command.IdTechnician);
        if (technician == null)
            throw new NotFoundArgumentException("Technician not found");
        technicianRepository.Remove(technician);
        await unitOfWork.CompleteAsync();
        return true;
    }
}