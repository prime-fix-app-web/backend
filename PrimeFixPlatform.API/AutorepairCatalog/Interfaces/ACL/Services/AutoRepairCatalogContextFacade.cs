using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL.Services;

/// <summary>
///     Context Facade for Auto Repair Catalog.
/// </summary>
/// <param name="autoRepairQueryService">
///     The Auto Repair Query Service.
/// </param>
/// <param name="autoRepairCommandService">
///     The Auto Repair Command Service.
/// </param>
public class AutoRepairCatalogContextFacade(IAutoRepairQueryService autoRepairQueryService,
    IAutoRepairCommandService autoRepairCommandService)
    : IAutoRepairCatalogContextFacade
{
    /// <summary>
    ///     Checks if an Auto Repair exists by its identifier.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The identifier of the Auto Repair to check.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, containing true if the Auto Repair exists; otherwise, false.
    /// </returns>
    public async Task<bool> ExistsAutoRepairByIdAsync(int autoRepairId)
    {
        var exitsAutoRepairByIdQuery = new ExistsAutoRepairByIdQuery(autoRepairId);
        return await autoRepairQueryService.Handle(exitsAutoRepairByIdQuery);
    }

    /// <summary>
    ///     Creates a new Auto Repair entry asynchronously.
    /// </summary>
    /// <param name="contactEmail">
    ///     The contact email for the Auto Repair.
    /// </param>
    /// <param name="ruc">
    ///     The RUC for the Auto Repair.
    /// </param>
    /// <param name="userAccountId">
    ///     The user account identifier associated with the Auto Repair.
    /// </param>
    /// <returns></returns>
    public async Task<int> CreateAutoRepairAsync(string contactEmail, string ruc, int userAccountId)
    {
        var createAutoRepairCommand = new CreateAutoRepairCommand(ruc, contactEmail, userAccountId);
        return await autoRepairCommandService.Handle(createAutoRepairCommand);
    }

    /// <summary>
    ///     Deletes an Auto Repair by its identifier asynchronously.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The identifier of the Auto Repair to delete.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    public async Task<bool> DeleteAutoRepairAsync(int autoRepairId)
    {
        var deleteAutoRepairCommand = new DeleteAutoRepairCommand(autoRepairId);
        return await autoRepairCommandService.Handle(deleteAutoRepairCommand);
    }
}