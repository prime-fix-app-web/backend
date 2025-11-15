using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
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
public class AutoRepairCommandService(IAutoRepairRepository autoRepairRepository, IUnitOfWork unitOfWork)
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
    public async Task<string> Handle(CreateAutoRepairCommand command)
    {
        var idAutoRepair = command.IdAutoRepair;
        var ruc = command.Ruc;
        var contactEmail = command.ContactEmail;
        
        if (await autoRepairRepository.ExistsByIdAutoRepair(idAutoRepair))
            throw new ConflictException("Auto repair with the same id " + idAutoRepair  + " already exists");
        
        if (await autoRepairRepository.ExistsByRuc(ruc))
            throw new ConflictException("Auto repair with the same RUC " + ruc  + " already exists");
        
        if (await autoRepairRepository.ExistsByContactEmail(contactEmail))
            throw new ConflictException("Auto repair with the same contact email " + contactEmail  + " already exists");
        
        var autoRepair = new AutoRepair(command);
        await autoRepairRepository.AddAsync(autoRepair);
        await unitOfWork.CompleteAsync();
        return autoRepair.IdAutoRepair;
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
        var idAutoRepair = command.IdAutoRepair;
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
        if (!await autoRepairRepository.ExistsByIdAutoRepair(command.IdAutoRepair))
            throw new NotFoundIdException("Auto repair with id " + command.IdAutoRepair  + " does not exist");
        var autoRepair = await autoRepairRepository.FindByIdAsync(command.IdAutoRepair);
        if (autoRepair is null)
            throw new NotFoundArgumentException("Auto repair not found");
        autoRepairRepository.Remove(autoRepair);
        await unitOfWork.CompleteAsync();
        return true;
    }
}