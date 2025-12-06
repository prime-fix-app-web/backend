using Cortex.Mediator;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.OutboundServices;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;
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
public class TechnicianCommandService(ITechnicianRepository technicianRepository,
    IUnitOfWork unitOfWork,
    IExternalAutoRepairCatalogServiceFromAutoRepairRegister externalAutoRepairCatalogServiceFromAutoRepairRegister,
    IMediator domainEventAutoRepairRegister)
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
    public async Task<int> Handle(CreateTechnicianCommand command)
    {
        // Check if the associated auto repair exists in the external Auto Repair Catalog Service
        var autoRepairId = command.AutoRepairId;
        if (!await externalAutoRepairCatalogServiceFromAutoRepairRegister.ExistsAutoRepairByIdAsync(autoRepairId))
            throw new NotFoundArgumentException("Auto repair with id " + autoRepairId + " does not exist in the Auto Repair Catalog Service");
        
        // Create the technician
        var technician = new Technician(command);
        await technicianRepository.AddAsync(technician);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the technician is created
        await domainEventAutoRepairRegister.PublishAsync(new TechnicianRegisteredEvent(technician.AutoRepairId));
        
        return technician.Id;
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
        // Check if the associated auto repair exists in the external Auto Repair Catalog Service
        var autoRepairId = command.AutoRepairId;
        if (!await externalAutoRepairCatalogServiceFromAutoRepairRegister.ExistsAutoRepairByIdAsync(autoRepairId))
            throw new NotFoundArgumentException("Auto repair with id " + autoRepairId + " does not exist in the Auto Repair Catalog Service");
        
        // Check if the technician exists
        var technicianId = command.TechnicianId;
        if (!await technicianRepository.ExistsByTechnicianId(technicianId))
            throw new NotFoundIdException("Technician with id " + technicianId  + " does not exist");
        
        // Retrieve the technician to update
        var technicianToUpdate = await technicianRepository.FindByIdAsync(technicianId);
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
        if (!await technicianRepository.ExistsByTechnicianId(command.TechnicianId))
            throw new NotFoundIdException("Technician with id " + command.TechnicianId  + " does not exist");
        var technician = await technicianRepository.FindByIdAsync(command.TechnicianId);
        if (technician == null)
            throw new NotFoundArgumentException("Technician not found");
        technicianRepository.Remove(technician);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the technician is deleted
        await domainEventAutoRepairRegister.PublishAsync(new TechnicianDeletedEvent(technician.AutoRepairId));
        
        return true;
    }
}