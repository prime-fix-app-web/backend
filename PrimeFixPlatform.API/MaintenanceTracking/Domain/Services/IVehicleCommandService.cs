using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;

/// <summary>
///     Represents a service for handling vehicle-related commands.
/// </summary>
public interface IVehicleCommandService
{
    /// <summary>
    ///     Handles the creation of a new vehicle.
    /// </summary>
    /// <param name="command">
    ///     The command containing vehicle creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Vehicle entity, or null if creation failed.
    /// </returns>
    Task<string> Handle(CreateVehicleCommand command);
    
    /// <summary>
    ///     Handles the update of an existing vehicle.
    /// </summary>
    /// <param name="command">
    ///     The command containing vehicle update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Vehicle entity, or null if the vehicle was not
    /// </returns>
    Task<Vehicle?> Handle(UpdateVehicleCommand command);
    
    /// <summary>
    ///     Handles the deletion of a vehicle.
    /// </summary>
    /// <param name="command">
    ///     The command containing vehicle deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteVehicleCommand command);
}