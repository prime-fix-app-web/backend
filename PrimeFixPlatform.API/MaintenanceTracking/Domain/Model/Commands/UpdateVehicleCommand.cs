using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to update a vehicle's information.
/// </summary>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle to be updated.
/// </param>
/// <param name="Color">
///     The new color of the vehicle to be updated.
/// </param>
/// <param name="Model">
///     The new model of the vehicle to be updated.
/// </param>
/// <param name="IdUser">
///     The unique identifier of the user performing the update.
/// </param>
/// <param name="VehicleInformation">
///     The updated vehicle information value object.
/// </param>
/// <param name="MaintenanceStatus">
///     The updated maintenance status of the vehicle to be updated.
/// </param>
public record UpdateVehicleCommand(string IdVehicle, string Color, string Model, string IdUser,
    VehicleInformation VehicleInformation, int MaintenanceStatus);