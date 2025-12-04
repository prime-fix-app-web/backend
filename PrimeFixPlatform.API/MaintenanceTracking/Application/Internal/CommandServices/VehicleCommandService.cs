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
public class VehicleCommandService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
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
        /*var idVehicle = command.IdVehicle;*/
        var vehiclePlate = command.VehicleInformation.VehiclePlate;
        
        /*if (await vehicleRepository.ExistsByIdVehicle(idVehicle))
            throw new ConflictException("Vehicle with the same id " + idVehicle  + " already exists");*/
        
        if (await vehicleRepository.ExistsByVehiclePlate(vehiclePlate))
            throw new ConflictException("Vehicle with the same plate " + vehiclePlate  + " already exists");

        var vehicle = new Vehicle(command);
        await vehicleRepository.AddAsync(vehicle);
        await unitOfWork.CompleteAsync();
        return vehicle.VehicleId;
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
        var idVehicle = command.VehicleId;
        var vehiclePlate = command.VehicleInformation.VehiclePlate;
        
        if (!await vehicleRepository.ExistsByIdVehicle(idVehicle))
            throw new NotFoundIdException("Vehicle with id " + idVehicle  + " does not exist");
        
        if (await vehicleRepository.ExistsByVehiclePlateAndIdVehicleIsNot(vehiclePlate, idVehicle))
            throw new ConflictException("Vehicle with the same plate " + vehiclePlate  + " already exists");
        
        var vehicleToUpdate = await vehicleRepository.FindByIdAsync(idVehicle);
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
        if (!await vehicleRepository.ExistsByIdVehicle(command.VehicleId))
            throw new NotFoundIdException("Vehicle with id " + command.VehicleId  + " does not exist");
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle is null)
            throw new NotFoundArgumentException("Vehicle not found");
        vehicleRepository.Remove(vehicle);
        await unitOfWork.CompleteAsync();
        return true;
    }
}