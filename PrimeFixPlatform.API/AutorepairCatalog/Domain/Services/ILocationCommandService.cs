using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;

/// <summary>
///     Represents a service for handling location-related commands.
/// </summary>
public interface ILocationCommandService
{
    /// <summary>
    ///     Handles the creation of a new location.
    /// </summary>
    /// <param name="command">
    ///     The command containing location creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Location entity, or null if creation failed.
    /// </returns>
    Task<string> Handle(CreateLocationCommand command);
    
    /// <summary>
    ///      Handles the update of an existing location.
    /// </summary>
    /// <param name="command">
    ///     The command containing location update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Location entity, or null if the location was not found.
    /// </returns>
    Task<Location?> Handle(UpdateLocationCommand command);
    
    /// <summary>
    ///     Handles the deletion of a location.
    /// </summary>
    /// <param name="command">
    ///     The command containing location deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteLocationCommand command);
}
