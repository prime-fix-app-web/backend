using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.CommandServices;

/// <summary>
///     Command service for AutoRepair aggregate
/// </summary>
/// <param name="autoRepairRepository">
///     The auto repair repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class AutoRepairCommandService(IAutoRepairRepository autoRepairRepository,IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
: IAutoRepairCommandService
{
    /// <summary>
    ///     Handles the command to create a new auto repair
    /// </summary>
    /// <param name="command">
    ///     The command to create a new auto repair
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created auto repair.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that an auto repair with the same id, RUC, or contact email already exists
    /// </exception>
    public async Task<int> Handle(CreateAutoRepairCommand command)
    {
        /*var idAutoRepair = command.;*/
        var ruc = command.Ruc;
        var contactEmail = command.ContactEmail;
        
        /*if (await autoRepairRepository.ExistsByIdAutoRepair(idAutoRepair))
            throw new ConflictException("Auto repair with the same id " + idAutoRepair  + " already exists");
        */
        if (await autoRepairRepository.ExistsByRuc(ruc))
            throw new ConflictException("Auto repair with the same RUC " + ruc  + " already exists");
        
        if (await autoRepairRepository.ExistsByContactEmail(contactEmail))
            throw new ConflictException("Auto repair with the same contact email " + contactEmail  + " already exists");
        
        var autoRepair = new AutoRepair(command);
        await autoRepairRepository.AddAsync(autoRepair);
        await unitOfWork.CompleteAsync();
        return autoRepair.AutoRepairId;
    }

    /// <summary>
    ///     Handles the command to update an existing auto repair
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing auto repair
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated auto repair.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that an auto repair with the specified id does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that another auto repair with the same RUC or contact email already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the auto repair to update was not found
    /// </exception>
    public async Task<AutoRepair?> Handle(UpdateAutoRepairCommand command)
    {
        var idAutoRepair = command.AutoRepairId;
        var ruc = command.Ruc;
        var contactEmail = command.ContactEmail;
        
        if (!await autoRepairRepository.ExistsByIdAutoRepair(idAutoRepair))
            throw new NotFoundIdException("Auto repair with id " + idAutoRepair  + " does not exist");
        
        if (await autoRepairRepository.ExistsByRucAndIdAutoRepairIsNot(ruc, idAutoRepair))
            throw new ConflictException("Auto repair with the same RUC " + ruc  + " already exists");
        
        if (await autoRepairRepository.ExistsByContactEmailAndIdAutoRepairIsNot(contactEmail, idAutoRepair))
            throw new ConflictException("Auto repair with the same contact email " + contactEmail  + " already exists");
        
        var autoRepairToUpdate = await autoRepairRepository.FindByIdAsync(idAutoRepair);
        if (autoRepairToUpdate is null)
            throw new NotFoundArgumentException("Auto repair not found");
        
        autoRepairToUpdate.UpdateAutoRepair(command);
        autoRepairRepository.Update(autoRepairToUpdate);
        await unitOfWork.CompleteAsync();
        return autoRepairToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing auto repair
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing auto repair
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that an auto repair with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the auto repair to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteAutoRepairCommand command)
    {
        if (!await autoRepairRepository.ExistsByIdAutoRepair(command.AutoRepairId))
            throw new NotFoundIdException("Auto repair with id " + command.AutoRepairId  + " does not exist");
        var autoRepair = await autoRepairRepository.FindByIdAsync(command.AutoRepairId);
        if (autoRepair is null)
            throw new NotFoundArgumentException("Auto repair not found");
        autoRepairRepository.Remove(autoRepair);
        await unitOfWork.CompleteAsync();
        return true;
    }
    
    /// <summary>
    /// Handles the command to add a new service offer to an auto repair service catalog.
    /// </summary>
    /// <param name="command">
    /// Command containing the data required to register a new service offer.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The result is <c>true</c> if the offer was successfully created.
    /// </returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the specified service or auto repair does not exist.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when a domain or persistence error occurs.
    /// </exception>
    public async Task<bool> Handle(AddServiceToAutoRepairServiceCatalogCommand command)
    {
        var service = await serviceRepository.FindByIdAsync(command.ServiceId) ?? throw new KeyNotFoundException($"Service with id {command.ServiceId} was not found");
        var autoRepair = await autoRepairRepository.FindByIdAsync(command.AutoRepairId) ?? throw new KeyNotFoundException($"AutoRepair with id {command.AutoRepairId} was not found");
        try
        {
            autoRepair.RegisterNewOffer(service, command.Price, command.DurationHours, command.IsActive);
            autoRepairRepository.Update(autoRepair);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error while saving the auto repair service offer: " + ex.Message, ex);
        }
    }

    
    
    /// <summary>
    /// Handles the command to remove a service offer from an auto repair service catalog.
    /// </summary>
    /// <param name="command">
    /// Command containing the data required to delete the service offer.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The result is <c>true</c> if the offer was successfully removed.
    /// </returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the specified service or auto repair does not exist.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when a domain error occurs while removing the service offer.
    /// </exception>
    public async Task<bool> Handle(DeleteServiceToAutoRepairServiceCommand command)
    {
        var service = await serviceRepository.FindByIdAsync(command.ServiceId)
                      ?? throw new KeyNotFoundException($"Service with id {command.ServiceId} was not found");

        var autoRepair = await autoRepairRepository.FindByIdAsync(command.AutoRepairId)
                         ?? throw new KeyNotFoundException($"AutoRepair with id {command.AutoRepairId} was not found");

        try
        {
            autoRepair.DeleteOffer(service);
            autoRepairRepository.Update(autoRepair);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (InvalidOperationException ex)
        {
            throw new ArgumentException(
                "Domain error while removing the offer: " + ex.Message,
                ex
            );
        }
    }
}