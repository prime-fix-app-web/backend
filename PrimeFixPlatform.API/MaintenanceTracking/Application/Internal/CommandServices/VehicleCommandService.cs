using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.OutboundServices.ACL;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.CommandServices;

/// <summary>
///     Command service for Vehicle aggregate
/// </summary>
/// <param name="vehicleRepository">
///     The vehicle repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class VehicleCommandService(IVehicleRepository vehicleRepository,
    IExternalIamServiceFromMaintenanceTracking externalIamServiceFromMaintenanceTracking,
    IUnitOfWork unitOfWork)
: IVehicleCommandService
{
    /// <summary>
    ///     Handles the command to create a new vehicle
    /// </summary>
    /// <param name="command">
    ///     The command to create a new vehicle
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created vehicle.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a vehicle with the same plate already exists
    /// </exception>
    public async Task<int> Handle(CreateVehicleCommand command)
    {
        var vehiclePlate = command.VehicleInformation.VehiclePlate;
        var userId = command.UserId;
        
        // Check if user exists in IAM service
        if (!await externalIamServiceFromMaintenanceTracking.ExistsUserByIdAsync(userId))
            throw new NotFoundIdException("User with id " + userId + " does not exist in IAM service");

        // Check if user has permission to create a vehicle
        if (await externalIamServiceFromMaintenanceTracking.FetchRoleByUserId(command.UserId) == ERole.RoleAutoRepair)
        {
            throw new ConflictException("User with id " + userId + " has not permission to create a vehicle");
        }
        
        // Check for vehicle plate uniqueness
        if (await vehicleRepository.ExistsByVehiclePlate(vehiclePlate))
            throw new ConflictException("Vehicle with the same plate " + vehiclePlate  + " already exists");

        // Create and persist the new vehicle
        var vehicle = new Vehicle(command);
        await vehicleRepository.AddAsync(vehicle);
        await unitOfWork.CompleteAsync();
        return vehicle.Id;
    }

    /// <summary>
    ///     Handles the command to update an existing vehicle
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing vehicle
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated vehicle.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a vehicle with the specified id does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that another vehicle with the same plate already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the vehicle to update was not found
    /// </exception>
    public async Task<Vehicle?> Handle(UpdateVehicleCommand command)
    {
        var vehicleId = command.VehicleId;
        var userId = command.UserId;
        var vehiclePlate = command.VehicleInformation.VehiclePlate;
        
        // Check if vehicle exists
        if (!await vehicleRepository.ExistsByVehicleId(vehicleId))
            throw new NotFoundIdException("Vehicle with id " + vehicleId  + " does not exist");
        
        // Check if user exists in IAM service
        if (!await externalIamServiceFromMaintenanceTracking.ExistsUserByIdAsync(userId))
            throw new NotFoundIdException("User with id " + userId + " does not exist in IAM service");
        
        // Check for vehicle plate uniqueness excluding the current vehicle
        if (await vehicleRepository.ExistsByVehiclePlateAndIdVehicleIsNot(vehiclePlate, vehicleId))
            throw new ConflictException("Vehicle with the same plate " + vehiclePlate  + " already exists");
        
        // Update and persist the vehicle
        var vehicleToUpdate = await vehicleRepository.FindByIdAsync(vehicleId);
        if (vehicleToUpdate is null)
            throw new NotFoundArgumentException("Vehicle not found");
        vehicleToUpdate.UpdateVehicle(command);
        vehicleRepository.Update(vehicleToUpdate);
        await unitOfWork.CompleteAsync();
        return vehicleToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing vehicle
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing vehicle
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the vehicle was successfully deleted.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a vehicle with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the vehicle to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteVehicleCommand command)
    {
        if (!await vehicleRepository.ExistsByVehicleId(command.VehicleId))
            throw new NotFoundIdException("Vehicle with id " + command.VehicleId  + " does not exist");
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle is null)
            throw new NotFoundArgumentException("Vehicle not found");
        vehicleRepository.Remove(vehicle);
        await unitOfWork.CompleteAsync();
        return true;
    }
}