using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Vehicle-related requests, commands, and responses.
/// </summary>
public static class VehicleAssembler
{
    /// <summary>
    ///     Converts a CreateVehicleRequest to a CreateVehicleCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateVehicleRequest containing vehicle details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateVehicleCommand.
    /// </returns>
    public static CreateVehicleCommand ToCommandFromRequest(CreateVehicleRequest request)
    {
        return new CreateVehicleCommand(
             request.Color, request.Model, request.UserId,
            new VehicleInformation(request.VehicleBrand, request.VehiclePlate, request.VehicleType), request.MaintenanceStatus
            );
    }
    
    /// <summary>
    ///     Converts an UpdateVehicleRequest to an UpdateVehicleCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateVehicleRequest containing updated vehicle details.
    /// </param>
    /// <param name="idVehicle">
    ///     The identifier of the vehicle to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateVehicleCommand.
    /// </returns>
    public static UpdateVehicleCommand ToCommandFromRequest(UpdateVehicleRequest request, int idVehicle)
    {
        return new UpdateVehicleCommand(
            idVehicle, request.Color, request.Model, request.UserId,
            new VehicleInformation(request.VehicleBrand, request.VehiclePlate, request.VehicleType), request.MaintenanceStatus
            );
    }

    /// <summary>
    ///     Converts a Vehicle entity to a VehicleResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Vehicle entity containing vehicle details.
    /// </param>
    /// <returns>
    ///     The corresponding VehicleResponse.
    /// </returns>
    public static VehicleResponse ToResponseFromEntity(Vehicle entity)
    {
        return new VehicleResponse(
            entity.VehicleId, entity.Color, entity.Model, entity.UserId,
            entity.VehicleInformation.VehicleBrand, entity.VehicleInformation.VehiclePlate,
            entity.VehicleInformation.VehicleType, entity.MaintenanceStatus
            );
    }
}